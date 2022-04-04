
namespace Многоугольники
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.shapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildconvexHullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defenitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.andrewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borderColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip_plst = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_play = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_stop = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_undo_redo = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_undo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.toolStrip_plst.SuspendLayout();
            this.toolStrip_undo_redo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.shapeToolStripMenuItem,
            this.buildconvexHullToolStripMenuItem,
            this.changeToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // shapeToolStripMenuItem
            // 
            this.shapeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circleToolStripMenuItem,
            this.squareToolStripMenuItem,
            this.triangleToolStripMenuItem});
            this.shapeToolStripMenuItem.Name = "shapeToolStripMenuItem";
            this.shapeToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.shapeToolStripMenuItem.Text = "Shape";
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.circleToolStripMenuItem.Text = "Circle";
            this.circleToolStripMenuItem.Click += new System.EventHandler(this.circleToolStripMenuItem_Click);
            // 
            // squareToolStripMenuItem
            // 
            this.squareToolStripMenuItem.Name = "squareToolStripMenuItem";
            this.squareToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.squareToolStripMenuItem.Text = "Square";
            this.squareToolStripMenuItem.Click += new System.EventHandler(this.squareToolStripMenuItem_Click);
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.triangleToolStripMenuItem.Text = "Triangle";
            this.triangleToolStripMenuItem.Click += new System.EventHandler(this.triangleToolStripMenuItem_Click);
            // 
            // buildconvexHullToolStripMenuItem
            // 
            this.buildconvexHullToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defenitionToolStripMenuItem,
            this.andrewToolStripMenuItem});
            this.buildconvexHullToolStripMenuItem.Name = "buildconvexHullToolStripMenuItem";
            this.buildconvexHullToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.buildconvexHullToolStripMenuItem.Text = "BuildConvexHull";
            // 
            // defenitionToolStripMenuItem
            // 
            this.defenitionToolStripMenuItem.Name = "defenitionToolStripMenuItem";
            this.defenitionToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.defenitionToolStripMenuItem.Text = "Defenition";
            this.defenitionToolStripMenuItem.Click += new System.EventHandler(this.defenitionToolStripMenuItem_Click);
            // 
            // andrewToolStripMenuItem
            // 
            this.andrewToolStripMenuItem.Name = "andrewToolStripMenuItem";
            this.andrewToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.andrewToolStripMenuItem.Text = "Andrew";
            this.andrewToolStripMenuItem.Click += new System.EventHandler(this.andrewToolStripMenuItem_Click);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillColorToolStripMenuItem,
            this.borderColorToolStripMenuItem,
            this.radiusToolStripMenuItem});
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.changeToolStripMenuItem.Text = "Options";
            // 
            // fillColorToolStripMenuItem
            // 
            this.fillColorToolStripMenuItem.Name = "fillColorToolStripMenuItem";
            this.fillColorToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.fillColorToolStripMenuItem.Text = "Fill Color";
            this.fillColorToolStripMenuItem.Click += new System.EventHandler(this.fillColorToolStripMenuItem_Click_1);
            // 
            // borderColorToolStripMenuItem
            // 
            this.borderColorToolStripMenuItem.Name = "borderColorToolStripMenuItem";
            this.borderColorToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.borderColorToolStripMenuItem.Text = "Border Color";
            this.borderColorToolStripMenuItem.Click += new System.EventHandler(this.borderColorToolStripMenuItem_Click_1);
            // 
            // radiusToolStripMenuItem
            // 
            this.radiusToolStripMenuItem.Name = "radiusToolStripMenuItem";
            this.radiusToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.radiusToolStripMenuItem.Text = "Radius";
            this.radiusToolStripMenuItem.Click += new System.EventHandler(this.radiusToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip_plst
            // 
            this.toolStrip_plst.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_plst.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_play,
            this.toolStripButton_stop});
            this.toolStrip_plst.Location = new System.Drawing.Point(58, 24);
            this.toolStrip_plst.Name = "toolStrip_plst";
            this.toolStrip_plst.Size = new System.Drawing.Size(58, 25);
            this.toolStrip_plst.TabIndex = 3;
            this.toolStrip_plst.Text = "toolStrip1";
            // 
            // toolStripButton_play
            // 
            this.toolStripButton_play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_play.Image = global::Многоугольники.Properties.Resources.play;
            this.toolStripButton_play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_play.Name = "toolStripButton_play";
            this.toolStripButton_play.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_play.Text = "toolStripButton1";
            this.toolStripButton_play.Click += new System.EventHandler(this.toolStripButton_play_Click);
            // 
            // toolStripButton_stop
            // 
            this.toolStripButton_stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_stop.Image = global::Многоугольники.Properties.Resources.stop;
            this.toolStripButton_stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_stop.Name = "toolStripButton_stop";
            this.toolStripButton_stop.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_stop.Text = "toolStripButton1";
            this.toolStripButton_stop.Click += new System.EventHandler(this.toolStripButton_stop_Click);
            // 
            // toolStrip_undo_redo
            // 
            this.toolStrip_undo_redo.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_undo_redo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_undo,
            this.toolStripButton1});
            this.toolStrip_undo_redo.Location = new System.Drawing.Point(0, 24);
            this.toolStrip_undo_redo.Name = "toolStrip_undo_redo";
            this.toolStrip_undo_redo.Size = new System.Drawing.Size(58, 25);
            this.toolStrip_undo_redo.TabIndex = 4;
            this.toolStrip_undo_redo.Text = "toolStrip1";
            // 
            // toolStripButton_undo
            // 
            this.toolStripButton_undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_undo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_undo.Image")));
            this.toolStripButton_undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_undo.Name = "toolStripButton_undo";
            this.toolStripButton_undo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_undo.Text = "toolStripButton1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip_undo_redo);
            this.Controls.Add(this.toolStrip_plst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Form1";
            this.Text = "Polygons";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.toolStrip_plst.ResumeLayout(false);
            this.toolStrip_plst.PerformLayout();
            this.toolStrip_undo_redo.ResumeLayout(false);
            this.toolStrip_undo_redo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem buildconvexHullToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defenitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem andrewToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem shapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borderColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiusToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStrip toolStrip_plst;
        private System.Windows.Forms.ToolStripButton toolStripButton_play;
        private System.Windows.Forms.ToolStripButton toolStripButton_stop;
        private System.Windows.Forms.ToolStrip toolStrip_undo_redo;
        private System.Windows.Forms.ToolStripButton toolStripButton_undo;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}

