using STC.Models;
using STC.Services;
using STC.View.ClientViewModel;

namespace STC.Helpers
{
    public class ClientHelper
    {
        private ClientService clientService = new ClientService();

        public async Task<Client> CreateClient(CreateClienteViewModel model)
        {
            Client clientCreate = new Client
            {
                CliName = model.CliName,
                CliNameMother = model.CliNameMother,
                CliNameFather = model.CliNameFather,
                CliBirthDate = model.CliBirthDate,
                CliAddressStreet = model.CliAddressStreet,
                CliAddressNeighborhood = model.CliAddressNeighborhood,
                CliAddressFull = model.CliAddressFull,
                CliAddressNumber = model.CliAddressNumber,
                CliAddressCity = model.CliAddressCity,
                CliSchool = model.CliSchool,
                CliSchoolGrade = model.CliSchoolGrade,
                CliSchoolCity = model.CliSchoolCity,
                CliSchoolState = model.CliSchoolState,
                CliPhoneNumber = model.CliPhoneNumber,
                CliPhoneCell = model.CliPhoneCell,
                CliNote = model.CliNote,
                CliActive = model.CliActive,
            };

            await clientService.CreateClient(clientCreate);

            return clientCreate;
        }
    }
}