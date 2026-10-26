namespace GUI
{
    partial class FormEstadisticas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelFiltro = new System.Windows.Forms.Panel();
            this.lblFiltroTitle = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnMesActual = new System.Windows.Forms.Button();
            this.panelKpiFacturacion = new System.Windows.Forms.Panel();
            this.lblKpiFacturacionTitulo = new System.Windows.Forms.Label();
            this.lblTotalFacturado = new System.Windows.Forms.Label();
            this.panelKpiTurnos = new System.Windows.Forms.Panel();
            this.lblKpiTurnosTitulo = new System.Windows.Forms.Label();
            this.lblTotalTurnos = new System.Windows.Forms.Label();
            this.panelKpiPromedio = new System.Windows.Forms.Panel();
            this.lblKpiPromedioTitulo = new System.Windows.Forms.Label();
            this.lblTicketPromedio = new System.Windows.Forms.Label();
            this.panelChart1 = new System.Windows.Forms.Panel();
            this.lblChart1Title = new System.Windows.Forms.Label();
            this.sepChart1 = new System.Windows.Forms.Panel();
            this.chartFacturacion = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelChart2 = new System.Windows.Forms.Panel();
            this.lblChart2Title = new System.Windows.Forms.Label();
            this.sepChart2 = new System.Windows.Forms.Panel();
            this.chartServicios = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelHeader.SuspendLayout();
            this.panelFiltro.SuspendLayout();
            this.panelKpiFacturacion.SuspendLayout();
            this.panelKpiTurnos.SuspendLayout();
            this.panelKpiPromedio.SuspendLayout();
            this.panelChart1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFacturacion)).BeginInit();
            this.panelChart2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.lblSubtitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1100, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(306, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📊  Estadísticas y Reportes";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(223)))), ((int)(((byte)(219)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(24, 42);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(400, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Facturación acumulada por día y servicios más contratados en el mes";
            // 
            // panelFiltro
            // 
            this.panelFiltro.BackColor = System.Drawing.Color.White;
            this.panelFiltro.Controls.Add(this.lblFiltroTitle);
            this.panelFiltro.Controls.Add(this.lblMes);
            this.panelFiltro.Controls.Add(this.cmbMes);
            this.panelFiltro.Controls.Add(this.lblAnio);
            this.panelFiltro.Controls.Add(this.cmbAnio);
            this.panelFiltro.Controls.Add(this.btnFiltrar);
            this.panelFiltro.Controls.Add(this.btnMesActual);
            this.panelFiltro.Location = new System.Drawing.Point(20, 75);
            this.panelFiltro.Name = "panelFiltro";
            this.panelFiltro.Size = new System.Drawing.Size(1060, 52);
            this.panelFiltro.TabIndex = 1;
            this.panelFiltro.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBordeRedondeado_Paint);
            // 
            // lblFiltroTitle
            // 
            this.lblFiltroTitle.AutoSize = true;
            this.lblFiltroTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.lblFiltroTitle.Location = new System.Drawing.Point(15, 16);
            this.lblFiltroTitle.Name = "lblFiltroTitle";
            this.lblFiltroTitle.Size = new System.Drawing.Size(130, 19);
            this.lblFiltroTitle.TabIndex = 0;
            this.lblFiltroTitle.Text = "Período de análisis:";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.lblMes.Location = new System.Drawing.Point(165, 18);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(32, 15);
            this.lblMes.TabIndex = 1;
            this.lblMes.Text = "Mes:";
            // 
            // cmbMes
            // 
            this.cmbMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMes.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(203, 14);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(140, 25);
            this.cmbMes.TabIndex = 2;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.lblAnio.Location = new System.Drawing.Point(365, 18);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(32, 15);
            this.lblAnio.TabIndex = 3;
            this.lblAnio.Text = "Año:";
            // 
            // cmbAnio
            // 
            this.cmbAnio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAnio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(403, 14);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(100, 25);
            this.cmbAnio.TabIndex = 4;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(123)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(525, 12);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(150, 30);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.Text = "🔍  Actualizar Gráficos";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnMesActual
            // 
            this.btnMesActual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(144)))), ((int)(((byte)(156)))));
            this.btnMesActual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMesActual.FlatAppearance.BorderSize = 0;
            this.btnMesActual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMesActual.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMesActual.ForeColor = System.Drawing.Color.White;
            this.btnMesActual.Location = new System.Drawing.Point(685, 12);
            this.btnMesActual.Name = "btnMesActual";
            this.btnMesActual.Size = new System.Drawing.Size(120, 30);
            this.btnMesActual.TabIndex = 6;
            this.btnMesActual.Text = "⟳  Mes Actual";
            this.btnMesActual.UseVisualStyleBackColor = false;
            this.btnMesActual.Click += new System.EventHandler(this.btnMesActual_Click);
            // 
            // panelKpiFacturacion
            // 
            this.panelKpiFacturacion.BackColor = System.Drawing.Color.White;
            this.panelKpiFacturacion.Controls.Add(this.lblKpiFacturacionTitulo);
            this.panelKpiFacturacion.Controls.Add(this.lblTotalFacturado);
            this.panelKpiFacturacion.Location = new System.Drawing.Point(20, 137);
            this.panelKpiFacturacion.Name = "panelKpiFacturacion";
            this.panelKpiFacturacion.Size = new System.Drawing.Size(340, 75);
            this.panelKpiFacturacion.TabIndex = 2;
            this.panelKpiFacturacion.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBordeRedondeado_Paint);
            // 
            // lblKpiFacturacionTitulo
            // 
            this.lblKpiFacturacionTitulo.AutoSize = true;
            this.lblKpiFacturacionTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiFacturacionTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(144)))), ((int)(((byte)(156)))));
            this.lblKpiFacturacionTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblKpiFacturacionTitulo.Name = "lblKpiFacturacionTitulo";
            this.lblKpiFacturacionTitulo.Size = new System.Drawing.Size(139, 15);
            this.lblKpiFacturacionTitulo.TabIndex = 0;
            this.lblKpiFacturacionTitulo.Text = "FACTURACIÓN DEL MES";
            // 
            // lblTotalFacturado
            // 
            this.lblTotalFacturado.AutoSize = true;
            this.lblTotalFacturado.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFacturado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.lblTotalFacturado.Location = new System.Drawing.Point(13, 33);
            this.lblTotalFacturado.Name = "lblTotalFacturado";
            this.lblTotalFacturado.Size = new System.Drawing.Size(76, 31);
            this.lblTotalFacturado.TabIndex = 1;
            this.lblTotalFacturado.Text = "$ 0,00";
            // 
            // panelKpiTurnos
            // 
            this.panelKpiTurnos.BackColor = System.Drawing.Color.White;
            this.panelKpiTurnos.Controls.Add(this.lblKpiTurnosTitulo);
            this.panelKpiTurnos.Controls.Add(this.lblTotalTurnos);
            this.panelKpiTurnos.Location = new System.Drawing.Point(380, 137);
            this.panelKpiTurnos.Name = "panelKpiTurnos";
            this.panelKpiTurnos.Size = new System.Drawing.Size(340, 75);
            this.panelKpiTurnos.TabIndex = 3;
            this.panelKpiTurnos.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBordeRedondeado_Paint);
            // 
            // lblKpiTurnosTitulo
            // 
            this.lblKpiTurnosTitulo.AutoSize = true;
            this.lblKpiTurnosTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiTurnosTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(144)))), ((int)(((byte)(156)))));
            this.lblKpiTurnosTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblKpiTurnosTitulo.Name = "lblKpiTurnosTitulo";
            this.lblKpiTurnosTitulo.Size = new System.Drawing.Size(138, 15);
            this.lblKpiTurnosTitulo.TabIndex = 0;
            this.lblKpiTurnosTitulo.Text = "SERVICIOS REALIZADOS";
            // 
            // lblTotalTurnos
            // 
            this.lblTotalTurnos.AutoSize = true;
            this.lblTotalTurnos.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTurnos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.lblTotalTurnos.Location = new System.Drawing.Point(13, 33);
            this.lblTotalTurnos.Name = "lblTotalTurnos";
            this.lblTotalTurnos.Size = new System.Drawing.Size(102, 31);
            this.lblTotalTurnos.TabIndex = 1;
            this.lblTotalTurnos.Text = "0 turnos";
            // 
            // panelKpiPromedio
            // 
            this.panelKpiPromedio.BackColor = System.Drawing.Color.White;
            this.panelKpiPromedio.Controls.Add(this.lblKpiPromedioTitulo);
            this.panelKpiPromedio.Controls.Add(this.lblTicketPromedio);
            this.panelKpiPromedio.Location = new System.Drawing.Point(740, 137);
            this.panelKpiPromedio.Name = "panelKpiPromedio";
            this.panelKpiPromedio.Size = new System.Drawing.Size(340, 75);
            this.panelKpiPromedio.TabIndex = 4;
            this.panelKpiPromedio.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBordeRedondeado_Paint);
            // 
            // lblKpiPromedioTitulo
            // 
            this.lblKpiPromedioTitulo.AutoSize = true;
            this.lblKpiPromedioTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiPromedioTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(144)))), ((int)(((byte)(156)))));
            this.lblKpiPromedioTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblKpiPromedioTitulo.Name = "lblKpiPromedioTitulo";
            this.lblKpiPromedioTitulo.Size = new System.Drawing.Size(107, 15);
            this.lblKpiPromedioTitulo.TabIndex = 0;
            this.lblKpiPromedioTitulo.Text = "TICKET PROMEDIO";
            // 
            // lblTicketPromedio
            // 
            this.lblTicketPromedio.AutoSize = true;
            this.lblTicketPromedio.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketPromedio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(123)))));
            this.lblTicketPromedio.Location = new System.Drawing.Point(13, 33);
            this.lblTicketPromedio.Name = "lblTicketPromedio";
            this.lblTicketPromedio.Size = new System.Drawing.Size(76, 31);
            this.lblTicketPromedio.TabIndex = 1;
            this.lblTicketPromedio.Text = "$ 0,00";
            // 
            // panelChart1
            // 
            this.panelChart1.BackColor = System.Drawing.Color.White;
            this.panelChart1.Controls.Add(this.lblChart1Title);
            this.panelChart1.Controls.Add(this.sepChart1);
            this.panelChart1.Controls.Add(this.chartFacturacion);
            this.panelChart1.Location = new System.Drawing.Point(20, 225);
            this.panelChart1.Name = "panelChart1";
            this.panelChart1.Padding = new System.Windows.Forms.Padding(15);
            this.panelChart1.Size = new System.Drawing.Size(560, 420);
            this.panelChart1.TabIndex = 5;
            this.panelChart1.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBordeRedondeado_Paint);
            // 
            // lblChart1Title
            // 
            this.lblChart1Title.AutoSize = true;
            this.lblChart1Title.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChart1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.lblChart1Title.Location = new System.Drawing.Point(15, 12);
            this.lblChart1Title.Name = "lblChart1Title";
            this.lblChart1Title.Size = new System.Drawing.Size(217, 20);
            this.lblChart1Title.TabIndex = 0;
            this.lblChart1Title.Text = "Facturación Acumulada por Día";
            // 
            // sepChart1
            // 
            this.sepChart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.sepChart1.Location = new System.Drawing.Point(18, 36);
            this.sepChart1.Name = "sepChart1";
            this.sepChart1.Size = new System.Drawing.Size(50, 3);
            this.sepChart1.TabIndex = 1;
            // 
            // chartFacturacion
            // 
            chartArea1.AxisX.IsLabelAutoFit = true;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            chartArea1.AxisY.LabelStyle.Format = "C0";
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            chartArea1.Name = "ChartAreaFacturacion";
            this.chartFacturacion.ChartAreas.Add(chartArea1);
            this.chartFacturacion.Location = new System.Drawing.Point(15, 50);
            this.chartFacturacion.Name = "chartFacturacion";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartAreaFacturacion";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            series1.Font = new System.Drawing.Font("Segoe UI Semibold", 8F);
            series1.Name = "Facturacion";
            this.chartFacturacion.Series.Add(series1);
            this.chartFacturacion.Size = new System.Drawing.Size(530, 355);
            this.chartFacturacion.TabIndex = 2;
            this.chartFacturacion.Text = "chartFacturacion";
            // 
            // panelChart2
            // 
            this.panelChart2.BackColor = System.Drawing.Color.White;
            this.panelChart2.Controls.Add(this.lblChart2Title);
            this.panelChart2.Controls.Add(this.sepChart2);
            this.panelChart2.Controls.Add(this.chartServicios);
            this.panelChart2.Location = new System.Drawing.Point(600, 225);
            this.panelChart2.Name = "panelChart2";
            this.panelChart2.Padding = new System.Windows.Forms.Padding(15);
            this.panelChart2.Size = new System.Drawing.Size(480, 420);
            this.panelChart2.TabIndex = 6;
            this.panelChart2.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBordeRedondeado_Paint);
            // 
            // lblChart2Title
            // 
            this.lblChart2Title.AutoSize = true;
            this.lblChart2Title.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChart2Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.lblChart2Title.Location = new System.Drawing.Point(15, 12);
            this.lblChart2Title.Name = "lblChart2Title";
            this.lblChart2Title.Size = new System.Drawing.Size(262, 20);
            this.lblChart2Title.TabIndex = 0;
            this.lblChart2Title.Text = "Servicios Más Contratados en el Mes";
            // 
            // sepChart2
            // 
            this.sepChart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.sepChart2.Location = new System.Drawing.Point(18, 36);
            this.sepChart2.Name = "sepChart2";
            this.sepChart2.Size = new System.Drawing.Size(50, 3);
            this.sepChart2.TabIndex = 1;
            // 
            // chartServicios
            // 
            chartArea2.Name = "ChartAreaServicios";
            this.chartServicios.ChartAreas.Add(chartArea2);
            legend1.Font = new System.Drawing.Font("Segoe UI", 9F);
            legend1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            legend1.IsTextAutoFit = false;
            legend1.Name = "LegendServicios";
            this.chartServicios.Legends.Add(legend1);
            this.chartServicios.Location = new System.Drawing.Point(15, 50);
            this.chartServicios.Name = "chartServicios";
            series2.ChartArea = "ChartAreaServicios";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            series2.Legend = "LegendServicios";
            series2.Name = "Servicios";
            this.chartServicios.Series.Add(series2);
            this.chartServicios.Size = new System.Drawing.Size(450, 355);
            this.chartServicios.TabIndex = 2;
            this.chartServicios.Text = "chartServicios";
            // 
            // FormEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1100, 665);
            this.Controls.Add(this.panelChart2);
            this.Controls.Add(this.panelChart1);
            this.Controls.Add(this.panelKpiPromedio);
            this.Controls.Add(this.panelKpiTurnos);
            this.Controls.Add(this.panelKpiFacturacion);
            this.Controls.Add(this.panelFiltro);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormEstadisticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📊 Estadísticas y Reportes — AquaWash";
            this.Load += new System.EventHandler(this.FormEstadisticas_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFiltro.ResumeLayout(false);
            this.panelFiltro.PerformLayout();
            this.panelKpiFacturacion.ResumeLayout(false);
            this.panelKpiFacturacion.PerformLayout();
            this.panelKpiTurnos.ResumeLayout(false);
            this.panelKpiTurnos.PerformLayout();
            this.panelKpiPromedio.ResumeLayout(false);
            this.panelKpiPromedio.PerformLayout();
            this.panelChart1.ResumeLayout(false);
            this.panelChart1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFacturacion)).EndInit();
            this.panelChart2.ResumeLayout(false);
            this.panelChart2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartServicios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelFiltro;
        private System.Windows.Forms.Label lblFiltroTitle;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnMesActual;
        private System.Windows.Forms.Panel panelKpiFacturacion;
        private System.Windows.Forms.Label lblKpiFacturacionTitulo;
        private System.Windows.Forms.Label lblTotalFacturado;
        private System.Windows.Forms.Panel panelKpiTurnos;
        private System.Windows.Forms.Label lblKpiTurnosTitulo;
        private System.Windows.Forms.Label lblTotalTurnos;
        private System.Windows.Forms.Panel panelKpiPromedio;
        private System.Windows.Forms.Label lblKpiPromedioTitulo;
        private System.Windows.Forms.Label lblTicketPromedio;
        private System.Windows.Forms.Panel panelChart1;
        private System.Windows.Forms.Label lblChart1Title;
        private System.Windows.Forms.Panel sepChart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFacturacion;
        private System.Windows.Forms.Panel panelChart2;
        private System.Windows.Forms.Label lblChart2Title;
        private System.Windows.Forms.Panel sepChart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartServicios;
    }
}
