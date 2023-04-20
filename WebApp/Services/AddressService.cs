using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.Services
{
    public class AddressService
    {

        private readonly AddressRepository _addressRepo;
        private readonly UserAddressRepository _userAddressRepository;

        public AddressService(AddressRepository addressRepo)
        {
            _addressRepo = addressRepo;
        }

        public AddressService(UserAddressRepository userAddressRepository)
        {
            _userAddressRepository = userAddressRepository;
        }

        public async Task<AddressEntity> GetOrCreateAsync(AddressEntity addressEntity)
        {
            var entity = await _addressRepo.GetAsync(x =>
                x.StreetName == address.StreetName &&
                x.PostalCode == address.PostalCode &&
                x.City == address.City  
            );

            entity ??= await _addressRepo.AddAsync(addressEntity);
            return entity!;
        }

        public async Task AddAddressAsync(AppUser user, AddressEntity addressEntity)
        {
            await _userAddressRepository.AddAsync(new UserAddressEntity
            {
                UserId = user.Id,
                AddressId = addressEntity.Id,
            });
        }
    }
}
