using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SportBookApi.Data.Interface;
using SportBookApi.Model;
using SportBookApi.Model.DTO;
using System.Net;

namespace SportBookApi.Data.Repository
{
    public class BookingRepository : IRepository
    {
        private readonly BookingContext _dbContext;
        private readonly IMapper _mapper;

        public BookingRepository(IMapper mapper)
        {
            _dbContext = new BookingContext();
            _mapper = mapper;
        }
        // Create
        public async Task<Address> CreateAddressAsync(AddressDTO addressDto)
        {
            Address address = _mapper.Map<Address>(addressDto);

            using (var db = _dbContext)
            {
                await db.Addresses.AddAsync(address);
                await db.SaveChangesAsync();
            }

            return address;
        }

        public async Task<Booking> CreateBookingAsync(BookingDTO bookingDto)
        {
            Booking booking = _mapper.Map<Booking>(bookingDto);

            using (var db = _dbContext)
            {
                await db.Bookings.AddAsync(booking);
                await db.SaveChangesAsync();
            }

            return booking;
        }

        public async Task<Facility> CreateFacilityAsync(FacilityDTO facilityDto)
        {
            Facility facility = _mapper.Map<Facility>(facilityDto);

            using (var db = _dbContext)
            {
                await db.Facilities.AddAsync(facility);
                await db.SaveChangesAsync();
            }

            return facility;
        }


        public async Task<Review> CreateReviewAsync(ReviewDTO reviewDto)
        {
            Review review = _mapper.Map<Review>(reviewDto);

            using (var db = _dbContext)
            {
                await db.Reviews.AddAsync(review);
                await db.SaveChangesAsync();
            }

            return review;
        }

        public async Task<SportType> CreateSportTypeAsync(SportTypeDTO sportTypeDto)
        {
            SportType sportType = _mapper.Map<SportType>(sportTypeDto);

            using (var db = _dbContext)
            {
                await db.SportTypes.AddAsync(sportType);
                await db.SaveChangesAsync();
            }

            return sportType;
        }

        public async Task<User> CreateUserAsync(UserDTO userDto)
        {
            User user = _mapper.Map<User>(userDto);

            using (var db = _dbContext)
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
            }

            return user;
        }
        // Delete
        public async Task<bool> DeleteAddressAsync(int id)
        {
            using (var db = _dbContext)
            {
                Address a = await db.Addresses.FirstOrDefaultAsync(x => x.Id == id);

                if (a == null)
                {
                    return false;
                }
                else
                {
                    db.Addresses.Remove(a);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            using (var db = _dbContext)
            {
                Booking b = await db.Bookings.FirstOrDefaultAsync(x => x.Id == id);

                if (b == null)
                {
                    return false;
                }
                else
                {
                    db.Bookings.Remove(b);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteFacilityAsync(int id)
        {
            using (var db = _dbContext)
            {
                Facility f = await db.Facilities.FirstOrDefaultAsync(x => x.Id == id);

                if (f == null)
                {
                    return false;
                }
                else
                {
                    db.Facilities.Remove(f);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public Task<bool> DeleteReviewAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteSportTypeAsync(int id)
        {
            using (var db = _dbContext)
            {
                SportType s = await db.SportTypes.FirstOrDefaultAsync(x => x.Id == id);

                if (s == null)
                {
                    return false;
                }
                else
                {
                    db.SportTypes.Remove(s);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            using (var db = _dbContext)
            {
                User u = await db.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (u == null)
                {
                    return false;
                }
                else
                {
                    db.Users.Remove(u);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }
        // Read
        public async Task<AddressDTO> GetAddressAsync(int id)
        {
            Address address;

            using (var db = _dbContext)
            {
                address = await db.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            }

            return _mapper.Map<AddressDTO>(address);
        }

        public async Task<List<AddressDTO>> GetAddressesAsync()
        {
            List<Address> addresses;

            using (var db = _dbContext)
            {
                addresses = await db.Addresses.ToListAsync();
            }

            return _mapper.Map<List<AddressDTO>>(addresses);
        }

        public async Task<BookingDTO> GetBookingAsync(int id)
        {
            Booking booking;

            using (var db = _dbContext)
            {
                booking = await db.Bookings.FirstOrDefaultAsync(x => x.Id == id);
            }

            return _mapper.Map<BookingDTO>(booking);
        }

        public async Task<List<BookingDTO>> GetBookingsAsync()
        {
            List<Booking> bookings;

            using (var db = _dbContext)
            {
                bookings = await db.Bookings.ToListAsync();
            }

            return _mapper.Map<List<BookingDTO>>(bookings);
        }

        public async Task<List<FacilityDTO>> GetFacilitiesAsync()
        {
            List<Facility> facilities;

            using (var db = _dbContext)
            {
                facilities = await db.Facilities.ToListAsync();
            }

            return _mapper.Map<List<FacilityDTO>>(facilities);
        }

        public async Task<FacilityDTO> GetFacilityAsync(int id)
        {
            Facility facility;

            using (var db = _dbContext)
            {
                facility = await db.Facilities.FirstOrDefaultAsync(x => x.Id == id);
            }

            return _mapper.Map<FacilityDTO>(facility);
        }

        public async Task<ReviewDTO> GetReviewAsync(int id)
        {
            Review review;

            using (var db = _dbContext)
            {
                review = await db.Reviews.FirstOrDefaultAsync(x => x.Id == id);
            }

            return _mapper.Map<ReviewDTO>(review);
        }

        public async Task<List<ReviewDTO>> GetReviewsAsync()
        {
            List<Review> reviews;

            using (var db = _dbContext)
            {
                reviews = await db.Reviews.ToListAsync();
            }

            return _mapper.Map<List<ReviewDTO>>(reviews);
        }

        public async Task<SportTypeDTO> GetSportTypeAsync(int id)
        {
            SportType sportType;

            using (var db = _dbContext)
            {
                sportType = await db.SportTypes.FirstOrDefaultAsync(x => x.Id == id);
            }

            return _mapper.Map<SportTypeDTO>(sportType);
        }

        public async Task<List<SportTypeDTO>> GetSportTypesAsync()
        {
            List<SportType> sportTypes;

            using (var db = _dbContext)
            {
                sportTypes = await db.SportTypes.ToListAsync();
            }

            return _mapper.Map<List<SportTypeDTO>>(sportTypes);
        }

        public async Task<UserDTO> GetUserAsync(int id)
        {
            User user;

            using (var db = _dbContext)
            {
                user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            }

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            List<User> users;

            using (var db = _dbContext)
            {
                users = await db.Users.ToListAsync();
            }

            return _mapper.Map<List<UserDTO>>(users);
        }
        // Update
        public async Task<Address> UpdateAddressAsync(int id, AddressDTO addressDto)
        {
            Address chosenAddress;

            using (var db = _dbContext)
            {
                chosenAddress = await db.Addresses.FirstOrDefaultAsync(x => x.Id == id);

                if(chosenAddress == null)
                {
                    return null;
                }

                chosenAddress.Street = addressDto.Street;
                chosenAddress.City = addressDto.City;  
                chosenAddress.Municupality = addressDto.Municupality;
                chosenAddress.ZipCode = addressDto.ZipCode;

                await db.SaveChangesAsync();

                return chosenAddress;
            }
        }

        public async Task<Booking> UpdateBookingAsync(int id, BookingDTO bookingDto)
        {
            Booking chosenBooking;

            using (var db = _dbContext)
            {
                chosenBooking = await db.Bookings.FirstOrDefaultAsync(x => x.Id == id);

                if (chosenBooking == null)
                {
                    return null;
                }

                // I will have to create seperate UpdateDTO for this to work 
                chosenBooking.Date = bookingDto.Date;
                chosenBooking.Duration = bookingDto.Duration;
                chosenBooking.SportTypeId = bookingDto.SportTypeId;
                chosenBooking.FacilityId = bookingDto.FacilityId;

                await db.SaveChangesAsync();

                return chosenBooking;
            }
        }

        public async Task<Facility> UpdateFacilityAsync(int id, FacilityDTO facilityDto)
        {
            Facility chosenFacility;

            using (var db = _dbContext)
            {
                chosenFacility = await db.Facilities.FirstOrDefaultAsync(x => x.Id == id);

                if (chosenFacility == null)
                {
                    return null;
                }

                // I will have to create seperate UpdateDTO for this to work 
                chosenFacility.Name = facilityDto.Name;
                chosenFacility.AddressId = facilityDto.AddressId;

                await db.SaveChangesAsync();

                return chosenFacility;
            }
        }

        public async Task<Review> UpdateReviewAsync(int id, ReviewDTO reviewDto)
        {
            Review chosenReview;

            using (var db = _dbContext)
            {
                chosenReview = await db.Reviews.FirstOrDefaultAsync(x => x.Id == id);

                if (chosenReview == null)
                {
                    return null;
                }

                // I will have to create seperate UpdateDTO for this to work 
                chosenReview.WrittenReview = reviewDto.WrittenReview;
                chosenReview.UserId = reviewDto.UserId;
                chosenReview.FacilityId = reviewDto.FacilityId;

                await db.SaveChangesAsync();

                return chosenReview;
            }
        }

        public async Task<SportType> UpdateSportTypeAsync(int id, SportTypeDTO sportTypeDto)
        {
            SportType chosenSportType;

            using (var db = _dbContext)
            {
                chosenSportType = await db.SportTypes.FirstOrDefaultAsync(x => x.Id == id);

                if (chosenSportType == null)
                {
                    return null;
                }

                // I will have to create seperate UpdateDTO for this to work 
                chosenSportType.Name = sportTypeDto.Name;

                await db.SaveChangesAsync();

                return chosenSportType;
            }
        }

        public async Task<User> UpdateUserAsync(int id, UserDTO userDto)
        {
            User chosenUser;

            using (var db = _dbContext)
            {
                chosenUser = await db.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (chosenUser == null)
                {
                    return null;
                }

                // I will have to create seperate UpdateDTO for this to work 
                chosenUser.FirstName = userDto.FirstName;
                chosenUser.LastName = userDto.LastName;
                chosenUser.Age = userDto.Age;

                await db.SaveChangesAsync();

                return chosenUser;
            }
        }
    }
}
