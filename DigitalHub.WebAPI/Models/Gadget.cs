public class Gadget
{
	[Key]
	public int Id {get; set;}
	[Required]
	[MaxLength(200)]
	public string Name {get; set;} = string.Empty;
	public string Description {get; set;} = string.Empty;
	[Required]
	[Range(1, 9999999)]
	public double Price {get; set;}
	public int DiscountPercent {get; set;}
	public int CategoryId {get; set;}
	[ForeignKey("CategoryId")]
	[ValidateNever]
	public Category Category {get; set;}
	[ValidateNever]
	public string ImageUrl {get; set;} = string.Empty;
}