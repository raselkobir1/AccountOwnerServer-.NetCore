using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class OwnerDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; } 
        public string? Address { get; set; }

        public IEnumerable<AccountDto>? Accounts { get; set; }  


        public List<OwnerDto> SetOwnerDtoList(List<Owner> owners)
        {
            var ownersList1 = new List<OwnerDto>();
            foreach (var owner in owners)
            {
                var ownerDt = new OwnerDto()
                {
                    Id = owner.Id,
                    Name = owner.Name,
                    Address = owner.Address,
                    DateOfBirth = owner.DateOfBirth
                };
                ownersList1.Add(ownerDt);
            }
            return ownersList1;
        }
    }

}
