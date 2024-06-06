public class Category
{
	[Key]
	public int Id {get; set;}
	[Required]
	[MaxLength(30)]
	public string Name {get; set;} = string.Empty;
	[Range(1, 50)]
	public int DisplayOrder {get; set;}	
}