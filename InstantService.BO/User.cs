using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatnekNetSolution.Core.Models.BaseModel;
using InstantService.BO.Helpers.Enum;

namespace InstantService.BO
{
    /// <summary>
    /// User class
    /// </summary>
    [Table("Users")]
    public class User : Track
    {
        #region Properties (Public)

        /// <summary>
        /// Represent the firstname of the user
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Represent the lastname of the user
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Represent the password of the user
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Represent the email address of the user
        /// </summary>
        [Required, EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Represent the phone number of the user
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Represents the boolean that allows to know if the user is connected or not
        /// </summary>
        public bool? Isconnected { get; set; }

        /// <summary>
        /// Represent the last connection of the user
        /// </summary>
        public DateTime? LastconnecteAt { get; set; }

        /// <summary>
        /// Represent the Civility of the user
        /// </summary>
        public CivilityTypeEnum? Civility { get; set; }

        /// <summary>
        /// Represent the boolean that allows to know if the email address of the user has been confirmed or not 
        /// </summary>
        public bool? EmailConfirm { get; set; }

        /// <summary>
        /// Represent the confirmation code: whether in the verification 
        /// of the email address or in the recovery of the password 
        /// </summary>
        public string? CodeConfirm { get; set; }

        /// <summary>
        /// Represent the date of birth of the user
        /// </summary>
        [Required]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Represent the gender of the user
        /// </summary>
        public GenderTypeEnum? Gender { get; set; }
        
        /// <summary>
        /// Represent the steps of user registration
        /// </summary>
        public StepEnum? StepRegistration { get; set; }

        /// <summary>
        /// Represents the Country of the user
        /// </summary>
        [Required]
        public string  Country { get; set; }

        /// <summary>
        /// Represents the City of the user
        /// </summary>
        [Required]
        public string  City { get; set; }

        /// <summary>
        /// Represents the Street of the user
        /// </summary>
        [Required]
        public string  Street { get; set; }

        /// <summary>
        /// Represents the PostalCode of the user
        /// </summary>
        public string?  PostalCode { get; set; }

        /// <summary>
        /// Represents the FullAddressName of the user
        /// </summary>
        [Required]
        public string  FullAdressName { get; set; }

        /// <summary>
        /// Represent id paper number.
        /// </summary>
        public string IdPaperNumber { get; set; }

        /// <summary>
        /// Represent all face of id card.
        /// </summary>
        //[Required]
        //public Guid IdentityCardId { get; set; }

        /// <summary>
        /// Represent all face of id card (in pdf).
        /// </summary>
        //[Required]
        //public Media IdentityCard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [NotMapped] 
        public string? FullName { get; set; }

        /// <summary>
        /// Represent all collection for this user.
        /// </summary>
        public virtual ICollection<Collection>? Collections { get; set; }

        /// <summary>
        /// Represent all role for this user.
        /// </summary>
        public virtual ICollection<Role>? Roles { get; set; }
        
        #endregion

        #region Methodes (Public)

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public User CreateCopy()
        {
            return (User)Clone();
        }

        #endregion
    }
}
