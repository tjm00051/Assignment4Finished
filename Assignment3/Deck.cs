using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Assignment3
{
    public class Deck
    {
        private readonly List<Card> cards=new List<Card>();
        private readonly ImageList imageList;
        private readonly Random rng=new Random();
        public Deck(ImageList imageList)
        {
            this.imageList=imageList??throw new ArgumentNullException(nameof(imageList));
        }
        public void Shuffle()
        {
            cards.Clear();
            int count=imageList.Images.Count;
            for(int i=0;i<count;i++)
            {
                Image img=imageList.Images[i];
                string name=(imageList.Images.Keys.Count>i&&imageList.Images.Keys[i]!=null)
                   ?imageList.Images.Keys[i]!
                   :$"Card{i}";
                cards.Add(new Card(i,img,name));
            }
            for(int i=cards.Count-1;i>0;i--)
            {
                int j=rng.Next(i+1);
                var tmp=cards[i];
                cards[i]=cards[j];
                cards[j]=tmp;
            }
        }
        public Card DealCard()
        {
            if(cards.Count==0)return Card.NoCard;
            Card c=cards[0];
            cards.RemoveAt(0);
            return c;
        }
        public int Count=>cards.Count;
        public Card GetCard(int index)
        {
            if(index<0||index>=cards.Count)return Card.NoCard;
            return cards[index];
        }
        public void SwapCards(int index1,int index2)
        {
            if(index1<0||index1>=cards.Count)return;
            if(index2<0||index2>=cards.Count)return;
            if (index1==index2)return;
            var tmp=cards[index1];
            cards[index1]=cards[index2];
            cards[index2]=tmp;
        }
        public void RemoveCardById(int id)
        {
            for(int i=cards.Count-1;i>=0;i--)
            {
                if(cards[i].Id==id)cards.RemoveAt(i);
            }
        }
        public bool SaveHand(string filename,Card[] hand)
        {
            try
            {
                using (var writer=new StreamWriter(filename))
                {
                    foreach(var c in hand)
                    {
                        writer.WriteLine(c?.Id??-1);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool LoadHand(string filename,Card[] hand)
        {
            try
            {
                using(var reader=new StreamReader(filename))
                {
                    for(int i=0;i<hand.Length;i++)
                    {
                        string? line=reader.ReadLine();
                        if(line==null)
                        {
                            hand[i]=Card.NoCard;
                            continue;
                        }
                        if(!int.TryParse(line,out int id))
                        {
                            hand[i]=Card.NoCard;
                            continue;
                        }
                        if(id<0||id>=imageList.Images.Count)
                        {
                            hand[i]=Card.NoCard;
                        }
                        else
                        {
                            Image img=imageList.Images[id];
                            string name=(imageList.Images.Keys.Count>id&&imageList.Images.Keys[id]!=null)
                                          ? imageList.Images.Keys[id]!
                                          :$"Card{id}";
                            hand[i]=new Card(id,img,name);
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}