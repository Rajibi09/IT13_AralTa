using System;
using System.Windows.Forms;
using System.Drawing;

namespace IT13_project
{
    public class PrincipalDashboard : BaseDashboard
    {
        public PrincipalDashboard() : base("Principal")
        {
            InitializePrincipalDashboard();
        }

        private void InitializePrincipalDashboard()
        {
            // Principal use cases
            AddMenuButton("📈 View Analytics Dashboard", (s, e) => ShowContent("View Analytics Dashboard"));
            AddMenuButton("📊 Generate Reports", (s, e) => ShowContent("Generate Reports"));
            AddMenuButton("✅ Approve / Review Grades", (s, e) => ShowContent("Approve / Review Grades"));

            // Show default content
            ShowContent("Welcome to Principal Dashboard");
        }

        private void ShowContent(string contentType)
        {
            ClearContentPanel();

            // Create a modern card-based layout
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.BackColor = Color.FromArgb(240, 240, 240);
            mainPanel.AutoScroll = true;
            mainPanel.Padding = new Padding(20);

            // Title Section - only show on default/welcome screen
            if (contentType == "Welcome to Principal Dashboard")
            {
                Panel titlePanel = new Panel();
                titlePanel.Height = 80;
                titlePanel.Dock = DockStyle.Top;
                titlePanel.BackColor = Color.Transparent;

                Label titleLabel = new Label();
                titleLabel.Text = "📋 " + contentType;
                titleLabel.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Bold);
                titleLabel.ForeColor = Color.FromArgb(33, 33, 33);
                titleLabel.AutoSize = true;
                titleLabel.Location = new Point(0, 10);
                titlePanel.Controls.Add(titleLabel);

                Label descLabel = new Label();
                descLabel.Text = GetDescription(contentType);
                descLabel.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                descLabel.ForeColor = Color.FromArgb(100, 100, 100);
                descLabel.AutoSize = true;
                descLabel.Location = new Point(0, 50);
                descLabel.MaximumSize = new Size(600, 50);
                titlePanel.Controls.Add(descLabel);

                mainPanel.Controls.Add(titlePanel);
            }

            // Content Cards
            Panel cardsPanel = new Panel();
            cardsPanel.Dock = DockStyle.Top;
            cardsPanel.BackColor = Color.Transparent;
            cardsPanel.AutoSize = true;
            cardsPanel.Padding = new Padding(0, 20, 0, 0);

            switch (contentType)
            {
                case "View Analytics Dashboard":
                    AddAnalyticsCards(cardsPanel);
                    AddAnalyticsSampleTable(cardsPanel); // SAMPLE DATA
                    break;
                case "Generate Reports":
                    AddReportsCards(cardsPanel);
                    break;
                case "Approve / Review Grades":
                    AddApproveGradesCards(cardsPanel);
                    break;
                default:
                    AddWelcomeCards(cardsPanel);
                    break;
            }

            mainPanel.Controls.Add(cardsPanel);
            contentPanel.Controls.Add(mainPanel);
        }

        private string GetDescription(string contentType)
        {
            switch (contentType)
            {
                case "View Analytics Dashboard":
                    return "Monitor school performance and activity metrics.";
                case "Generate Reports":
                    return "Generate comprehensive school reports.";
                case "Approve / Review Grades":
                    return "Review and approve student grades from all classes.";
                default:
                    return "Welcome to your Principal Dashboard.";
            }
        }

        private void AddAnalyticsCards(Panel panel)
        {
            Panel headerPanel = CreateHeaderPanel("📈 View Analytics Dashboard", "Monitor school performance and activity metrics.", Color.FromArgb(0, 150, 136));
            panel.Controls.Add(headerPanel);

            string[] items = { "📊 Performance Metrics", "👥 Student Analytics", "📈 Grade Distribution", "📅 Attendance Trends", "💼 Staff Performance" };
            int xPos = 0;
            Panel cardRow = new Panel();
            cardRow.Location = new Point(0, 90);
            cardRow.Size = new Size(1000, 180);
            foreach (string item in items)
            {
                Panel card = CreateCard(item, 180, 150, Color.FromArgb(0, 150, 136));
                card.Location = new Point(xPos, 0);
                cardRow.Controls.Add(card);
                xPos += 200;
            }
            panel.Controls.Add(cardRow);
            panel.Height = 290;
        }

        // SAMPLE DATA: simple school analytics table
        private void AddAnalyticsSampleTable(Panel panel)
        {
            DataGridView dgv = new DataGridView();
            dgv.Width = 900;
            dgv.Height = 300;
            dgv.Location = new Point(0, 280);
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;

            dgv.Columns.Add("Metric", "Metric");
            dgv.Columns.Add("Value", "Value");

            dgv.Rows.Add("Avg Student Performance", "78.3%");
            dgv.Rows.Add("Avg Attendance", "91.2%");
            dgv.Rows.Add("Total Students", "1,234");
            dgv.Rows.Add("Total Staff", "124");

            panel.Controls.Add(dgv);
            panel.Height = 600;
        }

        private void AddReportsCards(Panel panel)
        {
            Panel headerPanel = CreateHeaderPanel("📊 Generate Reports", "Generate comprehensive school reports.", Color.FromArgb(0, 150, 136));
            panel.Controls.Add(headerPanel);

            string[] items = { "📄 Academic Year Report", "📊 Student Performance", "📅 Attendance Report", "👨‍💼 Staff Report", "💾 Export Report" };
            int xPos = 0;
            Panel cardRow = new Panel();
            cardRow.Location = new Point(0, 90);
            cardRow.Size = new Size(1000, 180);
            foreach (string item in items)
            {
                Panel card = CreateCard(item, 180, 150, Color.FromArgb(0, 150, 136));
                card.Location = new Point(xPos, 0);
                cardRow.Controls.Add(card);
                xPos += 200;
            }
            panel.Controls.Add(cardRow);
            panel.Height = 290;
        }

        private void AddApproveGradesCards(Panel panel)
        {
            Panel headerPanel = CreateHeaderPanel("✅ Approve / Review Grades", "Review and approve student grades from all classes.", Color.FromArgb(0, 150, 136));
            panel.Controls.Add(headerPanel);

            string[] items = { "👀 Review Submissions", "✅ Approve Grades", "🔍 Check Discrepancies", "⚖️ Compare Standards", "📋 Approval Report" };
            int xPos = 0;
            Panel cardRow = new Panel();
            cardRow.Location = new Point(0, 90);
            cardRow.Size = new Size(1000, 180);
            foreach (string item in items)
            {
                Panel card = CreateCard(item, 180, 150, Color.FromArgb(0, 150, 136));
                card.Location = new Point(xPos, 0);
                cardRow.Controls.Add(card);
                xPos += 200;
            }
            panel.Controls.Add(cardRow);
            panel.Height = 290;
        }

        private void AddWelcomeCards(Panel panel)
        {
            Label welcomeLabel = new Label();
            welcomeLabel.Text = "Welcome to Principal Dashboard";
            welcomeLabel.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
            welcomeLabel.ForeColor = Color.FromArgb(33, 33, 33);
            welcomeLabel.AutoSize = true;
            welcomeLabel.Location = new Point(0, 0);
            panel.Controls.Add(welcomeLabel);

            Label descLabel = new Label();
            descLabel.Text = "Monitor school analytics, generate reports, and approve student grades from all classes.";
            descLabel.Font = new Font("Microsoft Sans Serif", 12);
            descLabel.ForeColor = Color.FromArgb(100, 100, 100);
            descLabel.AutoSize = true;
            descLabel.Location = new Point(0, 40);
            descLabel.MaximumSize = new Size(800, 100);
            panel.Controls.Add(descLabel);

            panel.Height = 150;
        }

        private Panel CreateHeaderPanel(string title, string description, Color bgColor)
        {
            Panel headerPanel = new Panel();
            headerPanel.Location = new Point(0, 0);
            headerPanel.Size = new Size(900, 80);
            headerPanel.BackColor = bgColor;
            headerPanel.Padding = new Padding(15);

            Label headerTitle = new Label();
            headerTitle.Text = title;
            headerTitle.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
            headerTitle.ForeColor = Color.White;
            headerTitle.AutoSize = true;
            headerTitle.Location = new Point(15, 10);
            headerPanel.Controls.Add(headerTitle);

            Label headerDesc = new Label();
            headerDesc.Text = description;
            headerDesc.Font = new Font("Microsoft Sans Serif", 10);
            headerDesc.ForeColor = Color.FromArgb(200, 240, 235);
            headerDesc.AutoSize = true;
            headerDesc.Location = new Point(15, 40);
            headerPanel.Controls.Add(headerDesc);

            return headerPanel;
        }

        private Panel CreateCard(string title, int width, int height, Color hoverColor)
        {
            Panel card = new Panel();
            card.Width = width;
            card.Height = height;
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.None;
            card.Padding = new Padding(15);
            card.Cursor = Cursors.Hand;

            card.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(220, 220, 220), 1), 0, 0, card.Width - 1, card.Height - 1);
            };

            Label label = new Label();
            label.Text = title;
            label.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(33, 33, 33);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Fill;
            label.AutoSize = false;
            card.Controls.Add(label);

            card.MouseEnter += (s, e) =>
            {
                card.BackColor = hoverColor;
                label.ForeColor = Color.White;
            };

            card.MouseLeave += (s, e) =>
            {
                card.BackColor = Color.White;
                label.ForeColor = Color.FromArgb(33, 33, 33);
            };

            return card;
        }
    }
}