using System.Drawing;
namespace Assignment3
{
    public class Card
    {
        public int Id{get;}
        public Image? CardImage{get;}
        public string Name{get;}

        public Card(int id,Image?image,string name)
        {
            Id=id;
            CardImage=image;
            Name=name??id.ToString();
        }
        public override string ToString()=>Name;

        public static readonly Card NoCard=new Card(-1,null,"No Card");
    }
}