﻿using Qly_Luong_NVien_Service;
using Qly_NVien_Luong_Form.FormHandler.NhanVien;
using Qly_NVien_Luong_Form.FormOnly.NhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qly_NVien_Luong_Form.FormOnly
{
    public partial class MainControl : Form
    {
        private NhanVienService nhanVienService = new NhanVienService();

        public MainControl()
        {
            InitializeComponent();
            loadDataToTable();
        }

        private void loadDataToTable()
        {
            IList<Qly_Luong_NVien_Model.NhanVien> nhanVienList = nhanVienService.findAll().ToArray();
            var bindingList = new BindingList<Qly_Luong_NVien_Model.NhanVien>(nhanVienList);
            var source = new BindingSource(bindingList, null);
            this.tblData.DataSource = source;
        }

        /*Thêm dữ liệu*/
        private void onBtnAdd_Submit(object sender, EventArgs e)
        {
            Create form = new Create();
            form.ShowDialog();
            loadDataToTable();
        }

        /*Xem chi tiết dữ liệu*/
        private void viewThisRow(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = tblData.Rows[e.RowIndex];
                var id = selectedRow.Cells[0].Value;                
                Detail detail = new Detail(id);
                detail.ShowDialog();
            }
        }

        /*Sửa dòng dữ liệu*/
        private void editThisRow(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = tblData.SelectedRows[0];
                var id = selectedRow.Cells[0].Value;
                Edit form = new Edit(id);
                form.ShowDialog();
                loadDataToTable();
            } catch(Exception ex)
            {
                return;
            }
        }

        /*Xóa dòng dữ liệu*/
        private void removeThisRow(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa nhân viên này không?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var id = tblData.SelectedRows[0].Cells[0].Value;
                var nhanVien = nhanVienService.find((int)id);
                if (nhanVien != null)
                {
                    nhanVienService.update(nhanVien);
                    loadDataToTable();
                }
            }
        }
    }
}
