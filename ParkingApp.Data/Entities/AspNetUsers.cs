
namespace ParkingApp.Data.Entities
{
	public partial class AspNetUsers
	{
		#region Properties
		/// <summary>
		///  Id (System.String )
		/// </summary>
		public System.String Id { get; set; }
		/// <summary>
		///  UserName (System.String )
		/// </summary>
		public System.String UserName { get; set; }
		/// <summary>
		///  NormalizedUserName (System.String )
		/// </summary>
		public System.String NormalizedUserName { get; set; }
		/// <summary>
		///  Email (System.String )
		/// </summary>
		public System.String Email { get; set; }
		/// <summary>
		///  NormalizedEmail (System.String )
		/// </summary>
		public System.String NormalizedEmail { get; set; }
		/// <summary>
		///  EmailConfirmed (System.Boolean? )
		/// </summary>
		public System.Boolean? EmailConfirmed { get; set; }
		/// <summary>
		///  PasswordHash (System.String )
		/// </summary>
		public System.String PasswordHash { get; set; }
		/// <summary>
		///  SecurityStamp (System.String )
		/// </summary>
		public System.String SecurityStamp { get; set; }
		/// <summary>
		///  ConcurrencyStamp (System.String )
		/// </summary>
		public System.String ConcurrencyStamp { get; set; }
		/// <summary>
		///  PhoneNumber (System.String )
		/// </summary>
		public System.String PhoneNumber { get; set; }
		/// <summary>
		///  PhoneNumberConfirmed (System.Boolean? )
		/// </summary>
		public System.Boolean? PhoneNumberConfirmed { get; set; }
		/// <summary>
		///  TwoFactorEnabled (System.Boolean? )
		/// </summary>
		public System.Boolean? TwoFactorEnabled { get; set; }
		/// <summary>
		///  LockoutEnd (System.DateTime? )
		/// </summary>
		public System.DateTime? LockoutEnd { get; set; }
		/// <summary>
		///  LockoutEnabled (System.Boolean? )
		/// </summary>
		public System.Boolean? LockoutEnabled { get; set; }
		/// <summary>
		///  AccessFailedCount (System.Int32? )
		/// </summary>
		public System.Int32? AccessFailedCount { get; set; }
		/// <summary>
		///  Total Record (int)
		///  For serach result count
		/// </summary>
		public int TotalRecord { get; set; }
		#endregion
		
	}
}

