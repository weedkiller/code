    public abstract class RowOperation {
        public void apply(string status, Row row) {
            switch(status)
            {
                case: "Old"
                    this.OldCase(row);
                    break;
                case: "New"
                    this.NewCase(row);
                    break;
                default:
                    this.OtherCase(row);
                    break;
            }
        }
        abstract void OldCase(Cell);
        abstract void NewCase(Cell);
        abstract void OtherCase(cell);
    }
    
    public class ColorRow implements RowOperation {
        private static final ColorCells OP = new ColorCells();
        private ColorCells(){}
        // This operation isn't stateful so we use a singleton :D
        public static RowOperation getInstance() {
            return this.OP
        }
        public void OldCase(row) {
            row.BackColor = Color.Red;
        }
        public void NewCase(row) {
            row.BackColor = Color.Blue;
        }
        public void OtherCase(row) {
            row.BackColor = Color.White;
        }
    }
    
    public class CountRow implements CellOperation {
        public int oldRows = 0;
        public int newRows = 0;
        public int otherRows= 0;
        // This operation is stateful so we use the contructor
        public CountRow() {}
        public void OldCase(Row row) {
            oldRows++;
        }
        public void NewCase(Row row) {
            newRows++;
        }
        public void OtherCase(Row row) {
            otherRows++;
        }
    }
    
    // For each cell in the grid we will call each operation
    // function with the row status and the cells
    void UpdateRows(Grid grid, CellOperation[] operations)
    {
        foreach(Row row in grid.Rows)
        {
            string status = row.Cells["Status"]
    
            foreach(CellOperation op in operations)
            {
                op.apply(status, cell)
            }
        }
    }
