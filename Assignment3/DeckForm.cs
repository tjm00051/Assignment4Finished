using System;
using System.Windows.Forms;
namespace Assignment3
{
    public partial class DeckForm : Form
    {
        private readonly Deck deck;

        public DeckForm(Deck deck)
        {
            InitializeComponent();
            this.deck=deck??throw new ArgumentNullException(nameof(deck));
            deckListBox.SelectedIndexChanged+=DeckListBox_SelectedIndexChanged;
            upButton.Click+=UpButton_Click;
            downButton.Click+=DownButton_Click;
        }
        private void DeckForm_Load(object? sender,EventArgs e)
        {
            UpdateDeck();
        }
        public void UpdateDeck()
        {
            Card? selected=deckListBox.SelectedItem as Card;
            int selectedId=selected?.Id ?? -2;
            deckListBox.BeginUpdate();
            deckListBox.Items.Clear();
            for(int i=0;i<deck.Count;i++)
            {
                deckListBox.Items.Add(deck.GetCard(i));
            }
            if(selectedId>=0)
            {
                for(int i=0;i<deckListBox.Items.Count;i++)
                {
                    if((deckListBox.Items[i] as Card)?.Id==selectedId)
                    {
                        deckListBox.SetSelected(i,true);
                        break;
                    }
                }
            }
            deckListBox.EndUpdate();
        }
        private void DeckListBox_SelectedIndexChanged(object? sender,EventArgs e)
        {
            Card? card=deckListBox.SelectedItem as Card;
            cardPictureBox.Image=card?.CardImage;
        }
        private void UpButton_Click(object? sender,EventArgs e)
        {
            int idx=deckListBox.SelectedIndex;
            if (idx<=0) return;
            int newIndex=idx-1;
            deck.SwapCards(idx,newIndex);
            UpdateDeck();
            deckListBox.SetSelected(newIndex,true);
        }
        private void DownButton_Click(object? sender,EventArgs e)
        {
            int idx=deckListBox.SelectedIndex;
            if (idx<0||idx>=deck.Count-1)return;
            int newIndex=idx+1;
            deck.SwapCards(idx,newIndex);
            UpdateDeck();
            deckListBox.SetSelected(newIndex,true);
        }
        #region Designer
        private ListBox deckListBox;
        private PictureBox cardPictureBox;
        private Button upButton;
        private Button downButton;
        private Label cardsLabel;
        private void InitializeComponent()
        {
            cardsLabel=new Label();
            deckListBox=new ListBox();
            cardPictureBox=new PictureBox();
            upButton=new Button();
            downButton=new Button();
            SuspendLayout();
            cardsLabel.AutoSize=true;
            cardsLabel.Location=new System.Drawing.Point(12,9);
            cardsLabel.Name="cardsLabel";
            cardsLabel.Size=new System.Drawing.Size(40,15);
            cardsLabel.TabIndex=0;
            cardsLabel.Text = "&Cards";
            deckListBox.Location=new System.Drawing.Point(12,30);
            deckListBox.Name="deckListBox";
            deckListBox.Size=new System.Drawing.Size(200,300);
            deckListBox.TabIndex=1;
            deckListBox.IntegralHeight=false;
            deckListBox.FormattingEnabled=true;
            cardPictureBox.Location=new System.Drawing.Point(230,30);
            cardPictureBox.Name="cardPictureBox";
            cardPictureBox.Size=new System.Drawing.Size(120,170);
            cardPictureBox.SizeMode=PictureBoxSizeMode.StretchImage;
            cardPictureBox.TabIndex=2;
            upButton.Location=new System.Drawing.Point(12,340);
            upButton.Name="upButton";
            upButton.Size=new System.Drawing.Size(75,23);
            upButton.TabIndex=3;
            upButton.Text="&Up";
            upButton.UseVisualStyleBackColor=true;
            downButton.Location=new System.Drawing.Point(137,340);
            downButton.Name="downButton";
            downButton.Size=new System.Drawing.Size(75,23);
            downButton.TabIndex=4;
            downButton.Text="&Down";
            downButton.UseVisualStyleBackColor=true;
            ClientSize=new System.Drawing.Size(370,380);
            Controls.Add(cardsLabel);
            Controls.Add(deckListBox);
            Controls.Add(cardPictureBox);
            Controls.Add(upButton);
            Controls.Add(downButton);
            FormBorderStyle=FormBorderStyle.FixedDialog;
            MaximizeBox=false;
            MinimizeBox=false;
            Name="DeckForm";
            Text="Deck";
            StartPosition=FormStartPosition.CenterParent;
            Load+=DeckForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}