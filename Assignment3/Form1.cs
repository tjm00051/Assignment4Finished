using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Assignment3
{
    public partial class Assignment3Form : Form
    {
        private Deck deck;
        private Card[] hand=new Card[5];
        private ImageList imageListCards=new ImageList();
        private OpenFileDialog openFileDialog=new OpenFileDialog();
        private SaveFileDialog saveFileDialog=new SaveFileDialog();
        private CheckBox[] keepBoxes;
        private PictureBox[] cardBoxes;
        private DeckForm? deckFormInstance=null;
        public Assignment3Form()
        {
            InitializeComponent();
            deck=new Deck(imageListCards);
            for(int i=0;i<hand.Length;i++)hand[i]=Card.NoCard;
        }
        private void checkBox1_CheckedChanged(object sender,EventArgs e)
        {
        }
        private void Assignment3Form_Load(object sender,EventArgs e)
        {
            keepBoxes=new CheckBox[]{chkKeep1,chkKeep2,chkKeep3,chkKeep4,chkKeep5 };
            cardBoxes=new PictureBox[]{picCard1,picCard2,picCard3,picCard4,picCard5 };
            LoadCardImages();
            this.MaximizeBox=false;
            this.FormBorderStyle=FormBorderStyle.FixedDialog;
            btnDeal.Text="&Deal";
            btnSave.Text="&Save Hand";
            btnLoad.Text="&Load Hand";
            chkKeep1.Text="&Keep 1";
            chkKeep2.Text="&Keep 2";
            chkKeep3.Text="&Keep 3";
            chkKeep4.Text="&Keep 4";
            chkKeep5.Text="&Keep 5";
            deck.Shuffle();
            UpdateHandPictureBoxes();
        }
        private void btnDeal_Click(object sender,EventArgs e)
        {
            DealNewHand();
        }
        private void DealNewHand()
        {
            deck.Shuffle();
            for(int i=0;i<hand.Length;i++)
            {
                if(!keepBoxes[i].Checked)continue;
                var keptCard=hand[i];
                if(keptCard!=null&&keptCard.Id>=0)
                {
                    deck.RemoveCardById(keptCard.Id);
                }
            }
            for(int i=0;i<5;i++)
            {
                if(!keepBoxes[i].Checked)
                {
                    hand[i]=deck.DealCard();
                }
            }
            UpdateHandPictureBoxes();
            deckFormInstance?.UpdateDeck();
        }
        private void LoadCardImages()
        {
            imageListCards.ImageSize=new Size(120,170);
            string cardPath=Path.Combine(Application.StartupPath,"cards");
            imageListCards.Images.Clear();
            if (!Directory.Exists(cardPath))
            {
                MessageBox.Show("Card images folder not found! Place a 'cards' folder next to your .exe file.");
                return;
            }
            var files=Directory.GetFiles(cardPath,"*.png",SearchOption.TopDirectoryOnly);
            int ExtractNumber(string path)
            {
                string name=Path.GetFileNameWithoutExtension(path);
                var m=System.Text.RegularExpressions.Regex.Match(name,@"(\d+)(?!.*\d)");
                if (m.Success&&int.TryParse(m.Value,out int n))return n;
                return int.MinValue;
            }
            var list=files.Select(f=>new{Path=f,Index=ExtractNumber(f),Name=Path.GetFileName(f)}).ToList();
            int validCount=list.Count(x=>x.Index!=int.MinValue);
            if(validCount>=list.Count/2)
                list=list.OrderBy(x=>x.Index).ToList();
            else
                list=list.OrderBy(x=>x.Name).ToList();
            foreach(var item in list)
            {
                try
                {
                    using(var fs=new FileStream(item.Path,FileMode.Open,FileAccess.Read))
                    using (var img=Image.FromStream(fs))
                    {
                        imageListCards.Images.Add((Image)img.Clone());
                    }
                }
                catch
                {
                }
            }
            string[] ranks={"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King" };
            string[] suits={"Clubs","Diamonds","Hearts","Spades" };
            int shiftIfUnknown=0; 
            int detectedShift=int.MinValue;
            for(int i=0;i<imageListCards.Images.Count;i++)
            {
                string keyGuess=Path.GetFileNameWithoutExtension(list[i].Name).ToLower();                                          
                var digitMatch=System.Text.RegularExpressions.Regex.Match(keyGuess,@"\d+");
                if(digitMatch.Success&&int.TryParse(digitMatch.Value,out int fileNum))
                {
                    int fileRankIdx=(fileNum%13); 
                    int observedRankIdx=i%13;     
                    int candidateShift=(fileRankIdx-observedRankIdx+13)%13;
                    detectedShift=candidateShift; 
                    break;
                }
            }
            int shift=detectedShift==int.MinValue?shiftIfUnknown:detectedShift;
            int count=imageListCards.Images.Count;
            for(int i=0;i<count;i++)
            {
                int rankIndex=((i%13)-1)%13; 
                if(rankIndex<0)rankIndex+=13;
                int suitIndex=i/13;
                string friendly=$"{ranks[rankIndex]} of {suits[suitIndex]}";
                imageListCards.Images.SetKeyName(i,friendly);
            }
        }
        private void picCard_Click(object sender,EventArgs e)
        {
            PictureBox clicked=sender as PictureBox;
            if (clicked==null) return;
            int index=Array.IndexOf(cardBoxes,clicked);
            if (index>=0)
            {
                keepBoxes[index].Checked=!keepBoxes[index].Checked;
            }
        }
        private void btnLoad_Click(object sender,EventArgs e)
        {
            openFileDialog.Filter="Text Files|*.txt";
            openFileDialog.InitialDirectory=Application.StartupPath;
            openFileDialog.DefaultExt="txt";
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                for(int i=0;i<hand.Length;i++)
                {
                    hand[i]=Card.NoCard;
                    cardBoxes[i].Image=null;
                    keepBoxes[i].Checked=false;
                }
                if(!deck.LoadHand(openFileDialog.FileName,hand))
                {
                    MessageBox.Show("Error loading hand file.");
                    return;
                }
                UpdateHandPictureBoxes();
                deckFormInstance?.UpdateDeck();
            }
        }
        private void btnSave_Click(object sender,EventArgs e)
        {
            saveFileDialog.Filter="Text Files|*.txt";
            saveFileDialog.InitialDirectory=Application.StartupPath;
            saveFileDialog.DefaultExt="txt";
            if(saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                if(!deck.SaveHand(saveFileDialog.FileName,hand))
                {
                    MessageBox.Show("Error saving hand.");
                }
            }
        }
        private void checkBox3_CheckedChanged(object sender,EventArgs e)
        {
        }
        private void UpdateHandPictureBoxes()
        {
            picCard1.Image=hand[0].CardImage;
            picCard2.Image=hand[1].CardImage;
            picCard3.Image=hand[2].CardImage;
            picCard4.Image=hand[3].CardImage;
            picCard5.Image=hand[4].CardImage;
        }
        private void btnShowDeck_Click(object sender,EventArgs e)
        {
            if(deckFormInstance==null||deckFormInstance.IsDisposed)
            {
                deckFormInstance=new DeckForm(deck);
                deckFormInstance.FormClosed+=(s,ev)=>deckFormInstance=null;
                deckFormInstance.Show(this);
            }
            else if(!deckFormInstance.Visible)
            {
                deckFormInstance.Show(this);
            }
            else
            {
                deckFormInstance.BringToFront();
            }
        }
    }
}