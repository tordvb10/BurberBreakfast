using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.ServicesErrors;
using ErrorOr;
using System;
using System.Collections.Generic;

namespace BuberBreakfast.Models
{
    public class Breakfast
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 60;
        public const int MinDescriptionLength = 50;
        public const int MaxDescriptionLength = 150;
        public Guid Id { get; set; }
        public string Name { get; set;}
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set ; }
        public List<string> Savory { get; set; } = new List<string>(); // Initialize as empty list
        public List<string> Sweet { get; set; } = new List<string>(); // Initialize as empty list

        public Breakfast() { }

        private Breakfast(
            Guid id,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DateTime lastModifiedDateTime,
            List<string> savory,
            List<string> sweet
        ) {
            Id = id;
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            LastModifiedDateTime = lastModifiedDateTime;
            Savory.AddRange(savory); // Add the passed savory items to the list
            Sweet.AddRange(sweet); // Add the passed sweet items to the list
        }

        public static ErrorOr<Breakfast> Create(
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            List<string> savory,
            List<string> sweet,
            Guid? id = null
        )
        {
            // enforcing invariants
            List<Error> errors = new();
            if ( name.Length is < MinNameLength or > MaxNameLength)
            {
                errors.Add(Errors.Breakfast.InvalidName);
            }

            if ( description.Length is < MinDescriptionLength or > MaxDescriptionLength)
            {
                errors.Add(Errors.Breakfast.InvalidDescription);
            }

            if (errors.Count > 0)
            {
                return errors;
            }

            return new Breakfast(
                id ?? Guid.NewGuid(),
                name,
                description,
                startDateTime,
                endDateTime,
                DateTime.UtcNow,
                savory,
                sweet
            );
        }
        
        public static ErrorOr<Breakfast> From(CreateBreakfastRequest request)
        {
            return Create(
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                request.Savory,
                request.Sweet
            );
        }

        public static ErrorOr<Breakfast> From(Guid id, UpsertBreakfastRequest request)
        {
            return Create(
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                request.Savory,
                request.Sweet,
                id
            );
        }

    }
}
