using Client.API.Controllers;
using Client.Application;
using Client.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestClient.API.UnitTest
{
	[TestClass]
	public class ClientesControllersTest:BaseTest
	{
		private readonly IClienteService _service;
		[TestMethod]
		public async Task GetClientes() 
		{
			//Preparacion 
			var nombredb =  Guid.NewGuid().ToString();
			var context = apllicationDbContext(nombredb);
			var persona = new Persona() { Nombre = "Johandri", Genero = "M", Edad = 24, Identificacion = 123454, Direccion = "calle1", Telefono = "3163947989" };
			var persona1 = new Persona() { Nombre = "Josefa", Genero = "F", Edad = 100, Identificacion = 123456765, Direccion = "calle1", Telefono = "3163947989" };
			 
		context.Clientes.Add(new Cliente() {Contraseña="adsada", Persona=persona});
			context.Clientes.Add(new Cliente() { Contraseña = "adqd*_12", Persona = persona1 });

			await context.SaveChangesAsync();

			//var context2 = apllicationDbContext(nombredb);

			//Prueba

			var controller = new ClientesController(_service);
			var respuest =  controller.Get();

			// Validation
			var clientes = respuest.Value;
			Assert.AreEqual(2, clientes.Count);


		}
	}
}
