Imports System.Text

Public Class Form1
    Dim count As Integer = 0
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox3.Text <> Nothing Then
            ListBox1.Items.Add("[" & count & "]" & TextBox3.Text)
            count += 1
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ListBox1.SelectedItem = Nothing Then
            GoTo endhere
        End If
        count -= 1
        Dim deleteitem As String
        deleteitem = ListBox1.SelectedItem.ToString()
        'MsgBox(deleteitem) 'Debig for Checking is the selected item correct
        Dim delcode As Integer = deleteitem.Substring(1, 1)
        'MsgBox(delcode) 'Try to get the delcode from item selected
        For Each i In ListBox1.Items
            If i.ToString.Substring(1, 1) < delcode Then
                ListBox2.Items.Add(i)
            ElseIf i.ToString.Substring(1, 1) > delcode Then
                i = i.ToString.Substring(0, 1) & (i.ToString.Substring(1, 1) - 1) & i.ToString.Substring(2, i.ToString.Length - 2)
                ListBox2.Items.Add(i)
            Else

            End If
        Next
        ListBox2.Refresh()
        MovetoListbox1()
endhere:
    End Sub
    Private Sub MovetoListbox1()
        Application.DoEvents()
        ListBox1.Items.Clear()
        For Each i In ListBox2.Items

            ListBox1.Items.Add(i.ToString)
        Next
        ListBox2.Items.Clear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sb As New StringBuilder
        sb.AppendLine("'ArOZ Code File, please edit with special program to prevent error.")
        For Each i In ListBox1.Items
            sb.AppendLine(i.ToString)
        Next
        IO.File.WriteAllText((TextBox2.Text & "\" & TextBox1.Text), sb.ToString, System.Text.Encoding.GetEncoding(950))
        MsgBox("Export Done")
    End Sub
End Class
