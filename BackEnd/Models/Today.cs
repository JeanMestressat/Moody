public class Today
{
    public int Id { get; set; }
    public int Id_User { get; set; }
    public DateOnly Date { get; set; }
    public int Mood { get; set; }
    public bool Insomnie { get; set; }
    public bool Reveil { get; set; }
    public bool Manger { get; set; }
    public bool Sport { get; set; }
    public bool Interaction { get; set; }
    public bool Sortie { get; set; }

    public Today() { }

}