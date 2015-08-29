var edge = require('edge');
var express = require('express');
var bodyParser = require('body-parser');

var app = express();

app.use('/', express.static(require('path').join(__dirname, 'scripts')));

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

function handler(error, result) {
	if (error) {
		console.log("Error occured.");
		console.log(error);
		return;
	}
	console.log(result);
}

app.get('/', function (request, response) {

	//var helloWorld = edge.func(function () {
	//  /*async(input) => {
	//    return "Hurray! Inline C# works with edge.js!!!";
    //  }*/
	//});

	//var helloWorld = edge.func(
	//  'async(input) => {'+
	//	'return "Hurray! Inline C# works with edge.js!!!";'+
	//  '}'
	//);

	//helloWorld(null, function(error, result) {
	//  if (error) {
	//	console.log("Error occured.");
	//	console.log(error);
	//	return;
	//  }
	//  console.log(result);
	//});

	//var helloFromClass = edge.func(function () {
	//  /*
	//  using System.Threading.Tasks;
	//
	//  public class Startup
	//  {
	//	public async Task<object> Invoke(object input)
	//	{
	//	  return "Hurray! Inline C# class works with edge.js!!!";
	//	}
	//  } */
	//});

	//helloFromClass(10, function (error, result) {
	//  if(error){
	//	console.log("error occured...");
	//	console.log(error);
	//	return;
	//  }
	//  console.log(result);
	//});

	//var getPerson = edge.func(require('path').join(__dirname, 'Startup.cs'));
	//getPerson(null, handler);

	response.sendFile(__dirname + '/index.html');
});

function apiResponseHandler(request, response) {
	return function(error, result) {
		if (error) {
			response.status(500).send({error: error});
			return;
		}

		response.send(result);
	};
}

app.get('/api/employees', function (request, response) {
	var getEmployeesProxy = edge.func({
		assemblyFile: 'dlls\\EmployeeCRUD.dll',
		typeName: 'EmployeeCRUD.EmployeesOperations',
		methodName: 'GetEmployees'
	});

	getEmployeesProxy(null, apiResponseHandler(request, response));
});

app.post('/api/employees', function (request, response) {
	var addEmployeeProxy = edge.func({
		assemblyFile:"dlls\\EmployeeCRUD.dll",
		typeName:"EmployeeCRUD.EmployeesOperations",
		methodName: "AddEmployee"
	});

	addEmployeeProxy(request.body, apiResponseHandler(request, response));
});

app.put('/api/employees/:id', function (request, response) {
	var editEmployeeProxy = edge.func({
		assemblyFile:"dlls\\EmployeeCRUD.dll",
		typeName:"EmployeeCRUD.EmployeesOperations",
		methodName: "EditEmployee"
	});

	editEmployeeProxy(request.body, apiResponseHandler(request, response));
});

app.listen(3000, function () {
	console.log("Express server running on port 3000...");
});
