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

        public async Task<Booking> CreateBookingAsync(BookingDTO bookingDto, int userId)
        {
            Booking booking = _mapper.Map<Booking>(bookingDto);

            using (var db = _dbContext)
            {
                booking.Facility = await db.Facilities.FirstOrDefaultAsync(x => x.Id == booking.FacilityId);
                booking.SportType = await db.SportTypes.FirstOrDefaultAsync(x => x.Id == booking.SportTypeId);
                booking.Users.Add(await db.Users.FirstOrDefaultAsync(x => x.Id == userId));

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
                facility.Address = await db.Addresses.FirstOrDefaultAsync(x => x.Id == facility.AddressId);

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
                review.User = await db.Users.FirstOrDefaultAsync(x => x.Id == review.UserId);
                review.Facility = await db.Facilities.FirstOrDefaultAsync(x => x.Id == review.FacilityId);

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
                user.Address = await db.Addresses.FirstOrDefaultAsync(x => x.Id == user.AddressId);

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
                    List<User> usersToUpdate = await db.Users.Where(x => x.AddressId == a.Id).ToListAsync();
                    List<Facility> facilitiesToUpdate = await db.Facilities.Where(x => x.AddressId == a.Id).ToListAsync();
                    
                    var tasks = new List<Task>();

                    foreach (User u in usersToUpdate)
                    {
                        u.AddressId = null;
                        tasks.Add(db.SaveChangesAsync());
                    }
                    foreach (Facility f in facilitiesToUpdate)
                    {
                        f.AddressId = null;
                        tasks.Add(db.SaveChangesAsync());
                    }
                    await Task.WhenAll(tasks);
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

                    var tasks = new List<Task>();

                    List<Review> reviewsToUpdate = await db.Reviews.Where(x => x.FacilityId == f.Id).ToListAsync();

                    foreach (Review r in reviewsToUpdate)
                    {
                        r.UserId = null;
                        tasks.Add(db.SaveChangesAsync());
                    }
                    await Task.WhenAll(tasks);
                    db.Facilities.Remove(f);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            using (var db = _dbContext)
            {
                Review r = await db.Reviews.FirstOrDefaultAsync(x => x.Id == id);

                if (r == null)
                {
                    return false;
                }
                else
                {
                    db.Reviews.Remove(r);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
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
                    var tasks = new List<Task>();

                    List<Review> reviewsToUpdate = await db.Reviews.Where(x => x.UserId == u.Id).ToListAsync();
                    List<Booking> bookingsToUpdate = await db.Bookings.Where(x => x.Users.Contains(u)).ToListAsync();

                    foreach (Review r in reviewsToUpdate)
                    {
                        r.UserId = null;
                        tasks.Add(db.SaveChangesAsync());
                    }
                    foreach (Booking b in bookingsToUpdate)
                    {
                        b.Users.Remove(u);
                        tasks.Add(db.SaveChangesAsync());
                    }
                    await Task.WhenAll(tasks);
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

                // Kinda ugly ternary. But it works and saves space ;)
                chosenAddress.Street = (addressDto.Street != null) ? addressDto.Street : chosenAddress.Street;
                chosenAddress.City = (addressDto.City != null) ? addressDto.City : chosenAddress.City;
                chosenAddress.Municupality = (addressDto.Municupality != null) ? addressDto.Municupality : chosenAddress.Municupality;
                chosenAddress.ZipCode = (addressDto.ZipCode != null) ? addressDto.ZipCode : chosenAddress.ZipCode;

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

                chosenBooking.Duration = (bookingDto.Duration != null) ? bookingDto.Duration : chosenBooking.Duration;
                chosenBooking.SportTypeId = (bookingDto.SportTypeId != null) ? bookingDto.SportTypeId : chosenBooking.SportTypeId;
                chosenBooking.FacilityId = (bookingDto.FacilityId != null) ? bookingDto.FacilityId : chosenBooking.FacilityId;

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

                chosenFacility.Name = (facilityDto.Name != null) ? facilityDto.Name : chosenFacility.Name;
                chosenFacility.AddressId = (facilityDto.AddressId != null) ? facilityDto.AddressId : chosenFacility.AddressId;

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

                chosenReview.WrittenReview = (reviewDto.WrittenReview != null) ? reviewDto.WrittenReview : chosenReview.WrittenReview;
                chosenReview.UserId = (reviewDto.UserId != null) ? reviewDto.UserId : chosenReview.UserId;
                chosenReview.FacilityId = (reviewDto.FacilityId != null) ? reviewDto.FacilityId : chosenReview.FacilityId;

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

                chosenSportType.Name = (sportTypeDto.Name != null) ? sportTypeDto.Name : chosenSportType.Name;

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

                chosenUser.FirstName = (userDto.FirstName != null) ? userDto.FirstName : chosenUser.FirstName;
                chosenUser.LastName = (userDto.LastName != null) ? userDto.LastName : chosenUser.LastName;
                chosenUser.Age = (userDto.Age != null) ? userDto.Age : chosenUser.Age;

                await db.SaveChangesAsync();

                return chosenUser;
            }
        }
    }
}
