using SportBookApi.Model;
using SportBookApi.Model.DTO;

namespace SportBookApi.Data.Interface
{
    public interface IRepository
    {
        // Create (Potentially going to create seperate POST Dto's)
        Task<User> CreateUserAsync(UserDTO userDto);
        Task<SportType> CreateSportTypeAsync(SportTypeDTO sportTypeDto);
        Task<Facility> CreateFacilityAsync(FacilityDTO facilityDto);
        Task<Booking> CreateBookingAsync(BookingDTO bookingDto, int userId);
        Task<Review> CreateReviewAsync(ReviewDTO reviewDto);
        Task<Address> CreateAddressAsync(AddressDTO addressDto);
        // Read
        Task<List<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserAsync(int id);
        Task<List<SportTypeDTO>> GetSportTypesAsync();
        Task<SportTypeDTO> GetSportTypeAsync(int id);
        Task<List<FacilityDTO>> GetFacilitiesAsync();
        Task<FacilityDTO> GetFacilityAsync(int id);
        Task<List<BookingDTO>> GetBookingsAsync();
        Task<BookingDTO> GetBookingAsync(int id);
        Task<List<ReviewDTO>> GetReviewsAsync();
        Task<ReviewDTO> GetReviewAsync(int id);
        Task<List<AddressDTO>> GetAddressesAsync();
        Task<AddressDTO> GetAddressAsync(int id);
        // Update
        Task<User> UpdateUserAsync(int id, UserDTO userDto);
        Task<SportType> UpdateSportTypeAsync(int id, SportTypeDTO sportTypeDto);
        Task<Facility> UpdateFacilityAsync(int id, FacilityDTO facilityDto);
        Task<Booking> UpdateBookingAsync(int id, BookingDTO bookingDto);
        Task<Review> UpdateReviewAsync(int id, ReviewDTO reviewDto);
        Task<Address> UpdateAddressAsync(int id, AddressDTO addressDto);
        // Delete
        Task<bool> DeleteUserAsync(int id);
        Task<bool> DeleteSportTypeAsync(int id);
        Task<bool> DeleteFacilityAsync(int id);
        Task<bool> DeleteBookingAsync(int id);
        Task<bool> DeleteReviewAsync(int id);
        Task<bool> DeleteAddressAsync(int id);
    }
}
