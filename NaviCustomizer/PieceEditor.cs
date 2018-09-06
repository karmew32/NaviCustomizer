using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaviCustomizer
{
    public partial class PieceEditor : Form
    {
        NCLinqDataContext db = new NCLinqDataContext();
        bool editMode = false;
        string spId = "FOO";
        string spName = "FOO";
        string spColor = "Red";
        bool gridInitialized = false;
        public PieceEditor(bool edit, string idName)
        {
            editMode = edit;
            spId = idName;
            InitializeComponent();
        }

        enum errorType
        {
            NO_SQUARES_SELECTED,
            DISJOINT_OBJECTS,
            PIECE_NOT_NAMED,
            NAME_ALREADY_EXISTS,
        };
        string[] errorMsgs = new string[]
        {
            "At least one square must be selected.",
            "All the squares must be adjacent to each other.",
            "Please insert a name for the piece.",
            "A piece with that name already exists. Please pick a different name."
        };
        private void PieceEditor_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            createPieceBtn.Text = (editMode) ? "Save Changes" : "Create Piece";
            string[] colors = new string [] { "Red", "Orange", "Yellow", "Green", "Blue", "Purple", "Cyan", "Magenta"};
            for (int i = 0; i < 5; i++)
            {
                table.Columns.Add("", typeof(char));
            }
            for (int i = 0; i < 5; i++)
            {

                table.Rows.Add(" ", " ", " ", " ", " ");
            }

            for (int i = 0; i < colors.Length; i++)
            {
                colorDropDown.Items.Add(colors[i]);
            }
            colorDropDown.SelectedIndex = 0;
            editorGrid.DataSource = table;
            gridInitialized = true;
            editorGrid.Rows[0].Cells[0].Selected = false;
            if (editMode)
            {
                var q =
                    from a in db.pieces
                    where a.id == spId
                    select a;
                nameBox.DataBindings.Add("Text", q, "name");
                colorDropDown.DataBindings.Add("SelectedItem", q, "color");
                textureCheck.DataBindings.Add("Checked", q, "textured");
                spName = nameBox.Text;
                var pnts =
                    (from a in db.points
                    where a.id == spId
                    select a).ToList();
                foreach (point p in pnts)
                {
                    editorGrid.Rows[p.y].Cells[p.x].Style.BackColor = Color.FromName(spColor);
                    if (textureCheck.Checked)
                    {
                        editorGrid.Rows[p.y].Cells[p.x].Value = "+";
                    }
                    //editorGrid.Rows[p.y].Cells[p.x].Selected = true;
                    //editorGrid.Rows[p.y].Cells[p.x].Value = 1;
                }
            }
        }

        private void createPieceBtn_Click(object sender, EventArgs e)
        {
            List<Point> selectedPoints = getSelectedPoints();
            Queue<Point> pointQueue = new Queue<Point>();
            List<List<int>> labels = new List<List<int>>();
            for (int i = 0; i < 5; i++)
            {
                List<int> l = new List<int>();
                for(int j=0; j<5; j++)
                {
                    l.Add(0);
                    //editorGrid.Rows[i].Cells[j].Value = 0;
                }
                labels.Add(l);
            }
            int label = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (editorGrid.Rows[i].Cells[j].Style.BackColor != Color.Empty && labels[i][j] == 0)
                    {
                        labels[i][j] = label;
                        //editorGrid.Rows[i].Cells[j].Value = label;
                        Point p = new Point(j, i);
                        pointQueue.Enqueue(p);
                        while (pointQueue.Count > 0)
                        {
                            Tile t = new Tile(pointQueue.Peek().x,pointQueue.Peek().y);
                            pointQueue.Dequeue();
                            foreach(Point r in t.borderingPoints)
                            {
                                if (editorGrid.Rows[r.y].Cells[r.x].Style.BackColor != Color.Empty && labels[r.y][r.x] == 0)
                                {
                                    labels[r.y][r.x] = label;
                                    //editorGrid.Rows[r.y].Cells[r.x].Value = label;
                                    pointQueue.Enqueue(r);
                                }
                            }
                        }
                        label++;
                    }
                }
            }
            bool nameExists = false;
            var names =
                (from a in db.pieces
                 select a.name).ToList();

            foreach (String n in names)
            {
                if (n.Equals(nameBox.Text))
                {
                    if (!n.Equals(spName))
                    {
                        nameExists = true;
                    }
                }
            }
            if (label < 2)
            {
                showError((int)errorType.NO_SQUARES_SELECTED);
            }
            else if (label > 2)
            {
                showError((int)errorType.DISJOINT_OBJECTS);
            }
            else if (nameBox.Text == "")
            {
                showError((int)errorType.PIECE_NOT_NAMED);
            }
            else if (nameExists)
            {
                showError((int)errorType.NAME_ALREADY_EXISTS);
            }
            else
            {
                int minX = 10;
                int minY = 10;
                foreach (Point p in selectedPoints)
                {
                    if (p.x < minX)
                    {
                        minX = p.x;
                    }
                    if (p.y < minY)
                    {
                        minY = p.y;
                    }
                }
                Piece csPiece = new Piece(nameBox.Text, colorDropDown.Text, textureCheck.Checked, selectedPoints);
                csPiece.shift(-minX, -minY);

                
                if (!editMode)
                {
                    piece dbPiece = new piece
                    {
                        id = csPiece.id,
                        name = csPiece.name,
                        color = csPiece.color,
                        textured = csPiece.textured,
                        onGrid = false
                    };
                    db.pieces.InsertOnSubmit(dbPiece);
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception z)
                    {
                        Console.WriteLine(z);
                        // Make some adjustments.
                        // ...
                        // Try again.
                        //db.SubmitChanges();
                    }
                }
                else
                {
                    
                    var q =
                        from a in db.pieces
                        where a.id == spId
                        select a;

                    foreach (piece p in q)
                    {
                        p.name = csPiece.name;
                        p.color = csPiece.color;
                        p.textured = csPiece.textured;
                    }

                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception z)
                    {
                        Console.WriteLine(z);
                        // Provide for exceptions.
                    }

                    var pnts =
                        from a in db.points
                        where a.id == spId
                        select a;

                    db.points.DeleteAllOnSubmit(pnts);
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception z)
                    {
                        Console.WriteLine(z);
                        // Provide for exceptions.
                    }
                }

                foreach (Point p in csPiece.points)
                {
                    point dbPoint = new point
                    {
                        id = (editMode) ? spId : csPiece.id,
                        x = p.x,
                        y = p.y
                    };
                    db.points.InsertOnSubmit(dbPoint);
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception z)
                    {
                        Console.WriteLine(z);
                        // Make some adjustments.
                        // ...
                        // Try again.
                        //db.SubmitChanges();
                    }
                }
                MainWindow mw = (MainWindow)Application.OpenForms["MainWindow"];
                
                mw.updatePieceList();
                Close();
               
                
            }
        }

        private void showError(int errorType)
        {
            MessageBox.Show(errorMsgs[errorType], "Error", MessageBoxButtons.OK,
    MessageBoxIcon.Warning);
        }

        private void editorGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Color newColor = Color.Empty;
            if (editorGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Empty)
            {
                newColor = Color.FromName(spColor);
                if (textureCheck.Checked)
                {
                    editorGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "+";
                }
            }
            else
            {
                editorGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = " ";
            }
            editorGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = newColor;
            editorGrid.ClearSelection();
        }



        private void colorDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (gridInitialized)
            {
                spColor = (string)colorDropDown.SelectedItem;
                foreach (Point p in getSelectedPoints())
                {
                    editorGrid.Rows[p.y].Cells[p.x].Style.BackColor = Color.FromName(spColor);
                }
            }
        }

        private List<Point> getSelectedPoints()
        {
            List<Point> sp = new List<Point>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (editorGrid.Rows[i].Cells[j].Style.BackColor != Color.Empty)
                    {
                        sp.Add(new Point(j, i));
                    }
                }
            }
            return sp;
        }

        private void textureCheck_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Point p in getSelectedPoints())
            {
                editorGrid.Rows[p.y].Cells[p.x].Value = (textureCheck.Checked) ? "+" : " ";

            }
        }

        private void editorGrid_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Down:
                case Keys.Up:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                default:
                    break;
            }
        }
    }
}
