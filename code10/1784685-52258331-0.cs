        private void dgv_customAttributes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string chosenValue = dgv_customAttributes.Rows[ e.RowIndex ].Cells[ e.ColumnIndex ].ToString();
            if ( chosenValue != null ) {
                foreach (CustomAttribute attribute in customAttributes)
                {
                    if ( chosenValue == attribute.AttributeName )
                    {
                        attribute.AttributeValue = chosenValue;
                        break;
                    }
                }
            }
        }
