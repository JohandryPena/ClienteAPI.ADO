using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

using Microsoft.EntityFrameworkCore;
using Client.Domain;
using Client.Infrastructure;
using Client.Application;
using TestClient;

public class ClienteServiceTests : IClassFixture<InMemoryDatabaseTest>
{
    public readonly InMemoryDatabaseTest _fixture;

    public ClienteServiceTests(InMemoryDatabaseTest fixture)
    {
        _fixture = fixture;
    }


    [Fact]
    public async Task GetClientesConEstadoTrueAsync_ReturnsClientsWithTrueState()
    {
       
    // Arrange

        var clientsData = new List<Cliente>
        {
           new Cliente
    {
        ClienteId = 1,
        Estado = true,
        Persona = new Persona
        {
            Nombre = "Cliente 1",
            Genero = "Masculino",
            Edad = 30,
            Identificacion = 123456789,
            Direccion = "123 Main Street",
            Telefono = "555-123-4567"
        },
        Contraseña = "Contraseña1"
    },
    new Cliente
    {
        ClienteId = 2,
        Estado = false,
        Persona = new Persona
        {
            Nombre = "Cliente 2",
            Genero = "Femenino",
            Edad = 25,
            Identificacion = 987654321,
            Direccion = "456 Elm Street",
            Telefono = "555-987-6543"
        },
        Contraseña = "Contraseña2"
    },
    new Cliente
    {
        ClienteId = 3,
        Estado = true,
        Persona = new Persona
        {
            Nombre = "Cliente 3",
            Genero = "Masculino",
            Edad = 40,
            Identificacion = 543216789,
            Direccion = "789 Oak Street",
            Telefono = "555-543-2167"
        },
        Contraseña = "Contraseña3"
    }

        }.AsQueryable();
        _fixture._context.Clientes.AddRange(clientsData);
        _fixture._context.SaveChanges();

        var service = new ClienteService(new ClienteRepository(_fixture._context));

        // Act
        var clientsWithTrueState = await service.GetAllClientesAsync();

        // Assert
        Assert.Equal(2, clientsWithTrueState.Count); // Se esperan 2 clientes con Estado = true

    }
}
