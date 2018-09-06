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
    public partial class MainWindow : Form
    {


        int numPieces = 0;
        int totalColors = 0;
        List<string> colorList = new List<string>();
        bool listInitialized = false;
        int prevY = 0;
        int prevX = 0;
        bool isFirstCell = true;
        bool overlap = false;
        bool insertionMode = false;
        Piece currentPiece;
        Piece goldPiece;
        Piece defaultGoldPiece = new Piece("foogold", "Empty", false, new List<Point>());
        List<List<Tile>> gridTiles = new List<List<Tile>>();
        enum bugType
        {
            SAME_COLOR_TOUCHING,
            TEXTURED_ON_LINE,
            PLAIN_NOT_ON_LINE,
            TOO_MANY_COLORS
        };
        //List<Point> selectedPointList = new List<Point>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void mainWindow_Load(object sender, EventArgs e)
        {
            goldPiece = defaultGoldPiece;

            //var id = ((piece)pieceList.SelectedItem).name;
            DataTable table = new DataTable();
            DataTable colorer = new DataTable();
            for (int i = 0; i < 4; i++)
            {
                colorer.Columns.Add("", typeof(char));
            }
            colorer.Rows.Add(' ', ' ', ' ', ' ');
            colorLine.DataSource = colorer;
            colorLine.ClearSelection();
            for (int i = 0; i < 5; i++)
            {
                table.Columns.Add("", typeof(char));
            }
            for (int i = 0; i < 5; i++)
            {
                char ch = (i == 2) ? '=' : ' ';
                table.Rows.Add(ch, ch, ch, ch, ch);
            }
            for (int i = 0; i < 5; i++)
            {
                List<Tile> tl = new List<Tile>();
                for (int j = 0; j < 5; j++)
                {
                    tl.Add(new Tile(j, i));
                }
                gridTiles.Add(tl);
            }
            mainGrid.DataSource = table;
            var db = new NCLinqDataContext();
            var q =
              (from a in db.pieces
              where a.onGrid == true
              select a).ToList();
            foreach (piece p in q)
            {
                p.onGrid = false;
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
            updatePieceList();
            currentPiece = getCurrentPiece();
            mainGrid.Rows[0].Cells[0].Selected = false;
            pieceList.ClearSelected();
          

        }



        private void editPieceBtn_Click(object sender, EventArgs e)
        {
            var db = new NCLinqDataContext();
            string spId = "FOO";
            var q =
                (from a in db.pieces
                 where a.name == (string)pieceList.SelectedValue
                 select a.id).ToList();
            foreach (string s in q)
            {
                spId = s;
            }
            PieceEditor pieceEditor = new PieceEditor(true, spId);
            pieceEditor.ShowDialog();
        }

        public void updatePieceList()
        {
            var db = new NCLinqDataContext();
            /*var q =
                (from a in db.pieces
                 where (from b in db.points select b.id).Contains(a.id)
                 select a).ToList();*/
            var q =
                (from a in db.pieces
                 where a.onGrid == false
                 select a).ToList();
            numPieces = q.Count;
            var pnts =
                (from a in db.points
                 select a).ToList();
            if (numPieces > 0)
            {
                pieceList.DisplayMember = "name";
                pieceList.ValueMember = "name";
                pieceList.DataSource = q;
                editPieceBtn.Enabled = true;
                deletePieceBtn.Enabled = true;
            }
            else
            {
                pieceList.DataSource = null;
                editPieceBtn.Enabled = false;
                deletePieceBtn.Enabled = false;
            }
            listInitialized = true;
        }

        private void deletePieceBtn_Click(object sender, EventArgs e)
        {
            deletePiece();
        }

        private void deletePiece()
        {
            foreach (Point p in currentPiece.points)
            {
                mainGrid.Rows[p.y].Cells[p.x].Style.BackColor =
                    (gridTiles[p.y][p.x].parentPiece.color.Equals("Empty"))
                    ? Color.Empty
                    : Color.FromName(gridTiles[p.y][p.x].parentPiece.color);
                mainGrid.Rows[p.y].Cells[p.x].Value =
                    gridTiles[p.y][p.x].tileChar;
                mainGrid.Rows[p.y].Cells[p.x].Style.ForeColor = Color.Black;
            }
            var db = new NCLinqDataContext();
            var q =
                from a in db.pieces
                where a.name == (string)pieceList.SelectedValue
                select a;
            db.pieces.DeleteAllOnSubmit(q);
            try
            {
                db.SubmitChanges();
            }
            catch (Exception z)
            {
                Console.WriteLine(z);
                // Provide for exceptions.
            }
            updatePieceList();
        }

        private void createNewPieceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PieceEditor pieceEditor = new PieceEditor(false, "FOO");
            pieceEditor.ShowDialog();
        }

        private void deleteAllPiecesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isGridEmpty = true;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (mainGrid.Rows[i].Cells[j].Style.BackColor != Color.Empty)
                    {
                        isGridEmpty = false;
                    }
                }
            }
            if (!isGridEmpty)
            {
                MessageBox.Show("Cannot perform mass delete because the grid is not empty.", "Cannot Delete Pieces", MessageBoxButtons.OK,
    MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete all pieces?", "Delete All Pieces", MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    var db = new NCLinqDataContext();
                    var q =
                        from a in db.pieces
                        select a;
                    db.pieces.DeleteAllOnSubmit(q);
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception z)
                    {
                        Console.WriteLine(z);
                        // Provide for exceptions.
                    }
                    updatePieceList();
                }
            }
            
        }


        private void mainGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (numPieces > 0 && insertionMode)
            {
                if (isFirstCell)
                {
                    //prep piece for initial draw
                    currentPiece.shift(e.ColumnIndex, e.RowIndex);

                    if (currentPiece.getRightBound() > 4)
                    {
                        currentPiece.shift(4 - currentPiece.getRightBound(), 0);
                    }
                    if (currentPiece.getBottomBound() > 4)
                    {
                        currentPiece.shift(0, 4 - currentPiece.getBottomBound());
                    }

                    isFirstCell = false;
                }
                else
                {

                    if (prevX > e.ColumnIndex && currentPiece.getLeftBound() - 1 >= 0)
                    {
                        currentPiece.shift(-1, 0);

                    }
                    //if moving to right
                    else if (prevX < e.ColumnIndex && currentPiece.getRightBound() + 1 <= 4)
                    {
                        currentPiece.shift(1, 0);
                    }
                    //if moving up
                    if (prevY > e.RowIndex && currentPiece.getTopBound() - 1 >= 0)
                    {
                        currentPiece.shift(0, -1);
                    }
                    //if moving down
                    else if (prevY < e.RowIndex && currentPiece.getBottomBound() + 1 <= 4)
                    {
                        currentPiece.shift(0, 1);
                    }

                }
                fillCurrSpot();
                prevX = e.ColumnIndex;
                prevY = e.RowIndex;
                currentPiece.setRotationalBound();
                checkForOverlap();
            }
        }

        private void mainGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (numPieces > 0 && insertionMode)
            {
                if (!overlap)
                {
                    //mainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                    foreach (Point p in currentPiece.points)
                    {
                        mainGrid.Rows[p.y].Cells[p.x].Style.BackColor = Color.FromName(currentPiece.color);
                        gridTiles[p.y][p.x].parentPiece = currentPiece;
                        gridTiles[p.y][p.x].tileChar = (currentPiece.textured) ? '+' : gridTiles[p.y][p.x].baseTileChar;
                    }
                    var db = new NCLinqDataContext();
                    var q =
                        from a in db.pieces
                        where a.name == currentPiece.name
                        select a;

                    foreach (piece p in q)
                    {
                        p.onGrid = true;
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
                    colorList.Add(currentPiece.color);
                    updateColorLine();
                    updatePieceList();
                    //checkForOverlap();
                    pieceList.ClearSelected();
                }
                else
                {
                    MessageBox.Show("That space is not fully empty. Please find another place to put the piece.", "Error", MessageBoxButtons.OK,
    MessageBoxIcon.Warning);
                    emptyPrevSpot();
                }
                
            }
            else
            {
                if (!gridTiles[e.RowIndex][e.ColumnIndex].parentPiece.color.Equals("Empty"))
                {
                    //return current piece to normal in case it is the gold piece
                    foreach (Point p in currentPiece.points)
                    {
                        mainGrid.Rows[p.y].Cells[p.x].Style.BackColor = Color.FromName(currentPiece.color);
                    }
                    
                    currentPiece = gridTiles[e.RowIndex][e.ColumnIndex].parentPiece;
                    foreach (Point p in currentPiece.points)
                    {
                        mainGrid.Rows[p.y].Cells[p.x].Style.BackColor =
                            (mainGrid.Rows[p.y].Cells[p.x].Style.BackColor.Equals(Color.Goldenrod))
                            ? Color.FromName(currentPiece.color)
                            : Color.Goldenrod;

                    }
                    goldPiece = currentPiece;
                }
            }
            mainGrid.ClearSelection();
        }

        private void mainGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (numPieces > 0 && insertionMode)
            {
                emptyPrevSpot();
            }
        }

        private void mainGrid_MouseLeave(object sender, EventArgs e)
        {
            if (numPieces > 0 && insertionMode)
            {
                prevX = 0;
                prevY = 0;
                isFirstCell = true;
                currentPiece.shift(-currentPiece.getLeftBound(), -currentPiece.getTopBound());
            }
        }

        private void mainGrid_MouseEnter(object sender, EventArgs e)
        {
            mainGrid.Focus();
        }

        private void pieceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listInitialized)
            {
                    foreach (Point p in goldPiece.points)
                    {
                        mainGrid.Rows[p.y].Cells[p.x].Style.BackColor =
                            Color.FromName(goldPiece.color);
                    }

                currentPiece = getCurrentPiece();
                insertionMode = (pieceList.SelectedIndex >= 0) ? true : false;
                editPieceBtn.Enabled = insertionMode;
                deletePieceBtn.Enabled = insertionMode;
            }
        }

        private Piece getCurrentPiece()
        {
            string id = "BillAndTed";
            string name = "Foo";
            string color = "Red";
            bool textured = false;
            List<Point> pointList = new List<Point>();
            if (numPieces > 0)
            {
                var db = new NCLinqDataContext();
                var q =
                    (from a in db.pieces
                     where a.name == (string)pieceList.SelectedValue
                     select a).ToList();
                var pnts =
                    (from a in db.points
                     where (from b in db.pieces
                            where b.name == (string)pieceList.SelectedValue
                            select b.id).Contains(a.id)
                     select a).ToList();
                foreach (piece p in q)
                {
                    id = p.id;
                    name = p.name;
                    color = p.color;
                    textured = p.textured;
                }
                foreach (point p in pnts)
                {
                    pointList.Add(new Point(p.x, p.y));
                }
            }
            Piece pc = new Piece(name, color, textured, pointList);
            pc.id = id;
            return pc;
        }

        private void mainGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (numPieces > 0 && insertionMode)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        emptyPrevSpot();
                        currentPiece.rotateLeft();
                        fillCurrSpot();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.Right:
                        emptyPrevSpot();
                        currentPiece.rotateRight();
                        fillCurrSpot();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.Down:
                    case Keys.Up:
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.Delete:
                        deletePiece();
                        break;
                    default:
                        break;
                }
                checkForOverlap();
            }
            else
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
                    case Keys.Delete:
                        removePieceFromGrid();
                        break;
                    default:
                        break;
                }
            }
            mainGrid.ClearSelection();
            
        }

        private void emptyPrevSpot()
        {
            foreach (Point p in currentPiece.points)
            {
                mainGrid.Rows[p.y].Cells[p.x].Style.BackColor =
                    (gridTiles[p.y][p.x].parentPiece.color.Equals("Empty"))
                    ? Color.Empty
                    : Color.FromName(gridTiles[p.y][p.x].parentPiece.color);
                //mainGrid.Rows[p.y].Cells[p.x].Style.ForeColor = Color.Empty;
                mainGrid.Rows[p.y].Cells[p.x].Value = gridTiles[p.y][p.x].tileChar;
                mainGrid.Rows[p.y].Cells[p.x].Style.ForeColor = Color.Black;
            }
        }

        private void fillCurrSpot()
        {
            Color transColor = makeTranslucent(Color.FromName(currentPiece.color));
            foreach (Point p in currentPiece.points)
            {
                mainGrid.Rows[p.y].Cells[p.x].Style.BackColor = transColor;
                //mainGrid.Rows[p.y].Cells[p.x].Style.ForeColor = Color.Transparent;
                if (currentPiece.textured)
                {
                    mainGrid.Rows[p.y].Cells[p.x].Value = "+";
                }
            }
        }

        //since the grid didn't want to comply with Color.FromArgb
        private Color makeTranslucent(Color c)
        {
            byte newRed = c.R;
            byte newGreen = c.G;
            byte newBlue = c.B;
            if (c.R < 255)
            {
                newRed += (byte)((255 - c.R) / 2);
            }
            if (c.G < 255)
            {
                newGreen += (byte)((255 - c.G) / 2);
            }
            if (c.B < 255)
            {
                newBlue += (byte)((255 - c.B) / 2);
            }
            return Color.FromArgb(255, newRed, newGreen, newBlue);
        }

        private void checkForOverlap()
        {
            bool localOverlap = false;
            foreach (Point p in currentPiece.points)
            {
                mainGrid.Rows[p.y].Cells[p.x].Style.BackColor = makeTranslucent
                    (Color.FromName(currentPiece.color));
                if (!gridTiles[p.y][p.x].parentPiece.color.Equals("Empty"))
                {
                    localOverlap = true;
                }
            }
            if (localOverlap)
            {
                foreach (Point p in currentPiece.points)
                {
                    mainGrid.Rows[p.y].Cells[p.x].Value = "X";
                    mainGrid.Rows[p.y].Cells[p.x].Style.ForeColor = Color.Red;
                }
            }
            else
            {
                foreach (Point p in currentPiece.points)
                {
                    mainGrid.Rows[p.y].Cells[p.x].Value =
                        (currentPiece.textured)
                        ? "+"
                        : gridTiles[p.y][p.x].baseTileChar.ToString();
                    mainGrid.Rows[p.y].Cells[p.x].Style.ForeColor = Color.Black;
                }
            }
            overlap = localOverlap;
        }

        private void MainWindow_Click(object sender, EventArgs e)
        {
            if (!insertionMode)
            {
                foreach (Point p in currentPiece.points)
                {
                    mainGrid.Rows[p.y].Cells[p.x].Style.BackColor = Color.FromName(currentPiece.color);
                }
                goldPiece = defaultGoldPiece;
            }
            pieceList.ClearSelected();
        }

        private void removePieceFromGrid()
        {
            
            var db = new NCLinqDataContext();
            var q =
                from a in db.pieces
                where a.name == currentPiece.name
                select a;

            foreach (piece p in q)
            {
                p.onGrid = false;
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
            colorList.Remove(currentPiece.color);
            updateColorLine();
            updatePieceList();
            pieceList.ClearSelected();
            foreach (Point p in goldPiece.points)
            {
                mainGrid.Rows[p.y].Cells[p.x].Style.BackColor = Color.Empty;
                mainGrid.Rows[p.y].Cells[p.x].Value = gridTiles[p.y][p.x].baseTileChar;
                gridTiles[p.y][p.x].tileChar = gridTiles[p.y][p.x].baseTileChar;
                gridTiles[p.y][p.x].parentPiece = defaultGoldPiece;
            }
            goldPiece = defaultGoldPiece;
        }

        private void clearNaviCustomizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var db = new NCLinqDataContext();
            var q =
                from a in db.pieces
                select a;

            foreach (piece p in q)
            {
                p.onGrid = false;
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
            updatePieceList();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mainGrid.Rows[i].Cells[j].Style.BackColor = Color.Empty;
                    mainGrid.Rows[i].Cells[j].Value = gridTiles[i][j].baseTileChar;
                    gridTiles[i][j].tileChar = gridTiles[i][j].baseTileChar;
                    gridTiles[i][j].parentPiece = defaultGoldPiece;
                }
            }
            goldPiece = defaultGoldPiece;
        }

        private void checkBugsBtn_Click(object sender, EventArgs e)
        {
            List<Piece> piecesOnGrid = new List<Piece>();
            List<Bug> bugs = new List<Bug>();
            if (totalColors > 4)
            {
                bugs.Add(new Bug((int)bugType.TOO_MANY_COLORS, defaultGoldPiece, defaultGoldPiece));
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!piecesOnGrid.Contains(gridTiles[i][j].parentPiece) && !gridTiles[i][j].parentPiece.color.Equals("Empty"))
                    {
                        piecesOnGrid.Add(gridTiles[i][j].parentPiece);
                    }
                }
            }
            foreach (Piece pc in piecesOnGrid)
            {
                bool isPieceOnLine = false;
                foreach (Point p in pc.points)
                {
                    if (gridTiles[p.y][p.x].isPartOfLine())
                    {
                        isPieceOnLine = true;
                    }
                    foreach (Point r in gridTiles[p.y][p.x].borderingPoints)
                    {
                        if (gridTiles[p.y][p.x].parentPiece.color.Equals(gridTiles[r.y][r.x].parentPiece.color)
                            && gridTiles[p.y][p.x].parentPiece != gridTiles[r.y][r.x].parentPiece)
                        {
                            if (!isPairInBugList(bugs, gridTiles[p.y][p.x].parentPiece, gridTiles[r.y][r.x].parentPiece))
                            {
                                bugs.Add(new Bug((int)bugType.SAME_COLOR_TOUCHING, gridTiles[p.y][p.x].parentPiece, gridTiles[r.y][r.x].parentPiece));
                            }
                        }
                    }
                }
                if (pc.textured && isPieceOnLine)
                {
                    bugs.Add(new Bug((int)bugType.TEXTURED_ON_LINE, pc, defaultGoldPiece));
                }
                else if (!pc.textured && !isPieceOnLine)
                {
                    bugs.Add(new Bug((int)bugType.PLAIN_NOT_ON_LINE, pc, defaultGoldPiece));
                }
            }
            List<string> bugMsgs = new List<string>();
            foreach (Bug b in bugs)
            {
                bugMsgs.Add(b.bugMessage);
            }
            BugReport bugReport = new BugReport(bugMsgs);
            bugReport.ShowDialog();
        }

        private bool isPairInBugList(List<Bug> bugList, Piece one, Piece two)
        {
            foreach (Bug b in bugList)
            {
                if ((b.pieceOne == one && b.pieceTwo == two) || (b.pieceOne == two && b.pieceTwo == one))
                {
                    return true;
                }
            }
            return false;
        }

        private void colorLine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            colorLine.ClearSelection();
        }

        private void updateColorLine()
        {
            totalColors = colorList.Distinct().Count();
            int numColors =
                (colorList.Distinct().Count() < 4)
                ? colorList.Distinct().Count()
                : 4;
            List<string> uniqueColors = colorList.Distinct().ToList();
            for (int i = 0; i < 4; i++)
            {
                colorLine.Rows[0].Cells[i].Style.BackColor = Color.Empty;
            }
            for (int i = 0; i < numColors; i++)
            {
                colorLine.Rows[0].Cells[i].Style.BackColor = Color.FromName(uniqueColors[i]);
            }
        }

        private void colorLine_KeyDown(object sender, KeyEventArgs e)
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
;