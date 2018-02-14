/* Airline Reservation
 * 
 * Programmer: Bruno Penna Barbosa de Almeida 
 * ID# 7772825
 * Revision History
 *      Bruno P B Almeida, 2017.09.23: Created 
 *      Bruno P B Almeida, 2017.09.24: Documentation comments inserted
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Global variables 
        const int NUMBER_OF_COL = 3;
        const int NUMBER_OF_ROW = 5;
        const int WAITING_LIST = 10;
        string[,] bookingList = new string[NUMBER_OF_ROW, NUMBER_OF_COL];
        string[] waitingList = new string[WAITING_LIST];

        /// <summary>
        /// Form Load innitializing the booking and waiting list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < NUMBER_OF_ROW; i++)
            {
                for (int j = 0; j < NUMBER_OF_COL; j++)
                {
                    bookingList[i, j] = "";
                }
            }

            for (int i = 0; i < WAITING_LIST; i++)
            {
                waitingList[i] = "";
            }

            //MessageBox.Show("Please fill the required fields to add a passenger, or \n " +
            //    "Click on the appropriate buttons to check the list or the spot status.", "Airline Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /// <summary>
        /// Function to print the booking list to the rich text box 
        /// </summary>
        public void showBookingList()
        {
            string outPutText = "";
            for (int i = 0; i < NUMBER_OF_ROW; i++)
            {
                for (int j = 0; j < NUMBER_OF_COL; j++)
                {
                    outPutText += "[" + i + "," + j + "] -- " + bookingList[i, j] + "\n";
                }
            }
            rtxBookList.Text = outPutText;
        }
        /// <summary>
        /// Function to print the waiting list to the rich text box 
        /// </summary>
        private void showWaitingList()
        {
            string outPutText = "";
            
            for (int i = 0; i < WAITING_LIST; i++)
            {
                outPutText += "[" + i + "] -- " + waitingList[i] + "\n";
            }
            
            rtxWaitingList.Text = outPutText;
        }

        /// <summary>
        /// Funtion to fill all the spots with the same passenger name. Debug purposes only.
        /// </summary>
        private void fillAll()
        {
            DialogResult result =  MessageBox.Show("This action will replace all the actual list.\n Are you sure do you want to continue?",
                "Fill booking List", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.OK:
                    for (int i = 0; i < NUMBER_OF_ROW; i++)
                    {
                        for (int j = 0; j < NUMBER_OF_COL; j++)
                        {
                            bookingList[i, j] = "Friedrich Gauss";
                        }
                    }
                    showBookingList();
                    break;
                case DialogResult.Cancel:
                    return;
                default:
                    MessageBox.Show("This is not a valid action!");
                    return;
            }
        }

        /// <summary>
        /// Function to add a passenger to an available spot
        /// </summary>
        private void addPassenger()
        {
            int i = 0;
            int j = 0;

            if (!checkBookingList())
            {
                MessageBox.Show("There are no spots available on the booking list, the passenger will be added to waiting list.", "Waiting list redirection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                addWaitingList();
                showWaitingList();
                return;
            }
            else
            {
                try
                {
                    i = int.Parse(lstRow.Text);
                    try
                    {
                        j = int.Parse(lstCol.Text);
                        try
                        {
                            
                            if (txtName.Text == "")
                            {
                                throw new Exception("The name field cannot be empty, please type the passenger name.");
                            }
                            else if(bookingList[i, j]!="")
                            {
                                MessageBox.Show("The spot has already been reserved, please choose another available spot.", "Booking List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            bookingList[i, j] = txtName.Text;
                            MessageBox.Show("The passenger has been succesfully added to the list.", "Booking List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showBookingList();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Error in the name field: " + e.Message);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error in column selection: " + e.Message);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error in row selection: " + e.Message);
                } 
            }
        }

        /// <summary>
        /// Show the status (Not/Available) of a single selected spot
        /// </summary>
        private void showStatus()
        {
            int i = 0;
            int j = 0;

            try
            {
                i = int.Parse(lstRow.Text);
                try
                {
                    j = int.Parse(lstCol.Text);
                    if(bookingList[i,j]=="")
                    {
                        txtStatus.Text = "Available";
                    }
                    else
                    {
                        txtStatus.Text = "Not Available";
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error in column selection: " + e.Message);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in row selection: " + e.Message);
            }
        }

        /// <summary>
        /// Boolean function to check if there is available spots in the Booking List 
        /// </summary>
        /// <returns>Returns True for available spots</returns>
        private bool checkBookingList()
        {
            bool availableSpot = false;
            for (int i = 0; i < NUMBER_OF_ROW; i++)
            {
                for (int j = 0; j < NUMBER_OF_COL; j++)
                {
                    if(bookingList[i,j]=="")
                    {
                        availableSpot = true;
                        return availableSpot;
                    }
                }
            }
            return availableSpot;
        }

        /// <summary>
        /// Boolean function to check if there is any entry in the waiting list
        /// </summary>
        /// <returns>Returns True if there is any entry</returns>
        private bool checkWaitingList()
        {
            bool filledSpot = false;
            
            for (int j = 0; j < WAITING_LIST; j++)
            {
                if (waitingList[j] != "")
                {
                    filledSpot = true;
                    return filledSpot;
                }
            }
            return filledSpot;
        }

        /// <summary>
        /// Add the passenger to the waiting list
        /// </summary>
        private void addWaitingList()
        {
            if(checkBookingList())
            {
                MessageBox.Show("There are spots available on the booking list, please book the passenger to the flight.", "Booking list spots available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showBookingList();
                return;
            }
            else if(txtName.Text =="")
            {
                MessageBox.Show("The name field cannot be empty, please type the passenger name.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                for (int i = 0; i < WAITING_LIST; i++)
                {
                    if (waitingList[i] == "")
                    {
                        waitingList[i] = txtName.Text;
                        MessageBox.Show("The passenger has been succesfully added to the waiting list.", "Booking List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showWaitingList();
                        break;
                    }
                    else if (i == WAITING_LIST - 1)
                    {
                        MessageBox.Show("Sorry! There are no more spots in the waiting list.", "Waiting list error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showWaitingList();
                    }
                } 
            }
        }

        /// <summary>
        /// Remove a passenger from the booking list, and if there is 
        /// passengers in the waiting list it add the passenger to booking list 
        /// and refresh the waiting list.
        /// </summary>
        private void cancelBook()
        {
            int i = 0;
            int j = 0;

            try
            {
                i = int.Parse(lstRow.Text);
                try
                {
                    j = int.Parse(lstCol.Text);
                    if (bookingList[i, j] == "")
                    {
                        MessageBox.Show("This spot is already available", "Booking List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        showBookingList();
                        return;
                    }
                    else 
                    {
                        if(!checkWaitingList())
                        {
                            bookingList[i, j] = "";
                            MessageBox.Show("The booking has been cancelled.", "Booking List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            bookingList[i, j] = waitingList[0];
                            refreshWaitingList();
                            MessageBox.Show("The booking has been cancelled. \nThe first passenger in the waiting list has been added to the booking list.",
                                "Booking List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        showBookingList();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error in column selection: " + e.Message);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in row selection: " + e.Message);
            }


        }

        /// <summary>
        /// Refreshes the Waiting list moving all the passengers forwars in the list
        /// </summary>
        private void refreshWaitingList()
        {
            for (int i = 0; i < WAITING_LIST; i++)
            {
                if (i == WAITING_LIST - 1)
                {
                    waitingList[i] = "";
                }
                else
                {
                    waitingList[i] = waitingList[i + 1];
                }
            }
            showWaitingList();
        }


        //The next block of code is related to the button click events for each functional button on the form 

        private void btnShow_Click(object sender, EventArgs e)
        {
            showBookingList();
        }

        private void btnShowWaiting_Click(object sender, EventArgs e)
        {
            showWaitingList();
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            fillAll();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            addPassenger();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            showStatus();
        }

        private void btnAddToWaiting_Click(object sender, EventArgs e)
        {
            addWaitingList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelBook();
        }
    }
}
