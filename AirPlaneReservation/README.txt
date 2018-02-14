Problem Specification: (Airline Reservation System)

1.	Write a reservation system for an airline flight seating. Assume the airplane has 5 rows with 3 seats in each row. 

2.	Allow the user the following options:
a.	Add a passenger to the flight or waiting list.
i.	Request the passenger’s name. (Don’t restrict the length, I should be able to book with a passenger’s name having a single letter, e.g., “a”)
ii.	Display a chart of the seats in the airplane. (When “All Seats” are pressed);
iii.	If seats are available, let the passenger choose a seat. Update the passenger to the seating chart
iv.	You cannot add a person to waiting list (size 10) if there are seats available.
v.	If no seats are available, place the passenger to the waiting list. In this case, “Book” and “Add to waiting list” buttons will do the same thing (the person will be added to the waiting list). If waiting list is full don’t add to waiting list, just show a message that the waiting list if full. (Assume there are 10 seats in waiting list)
vi.	If seats are available, “add to waiting list” button will not do anything, except showing a message “Seats are available”.
vii.	By pressing “Status” button, the status (Available/Not Available) will be shown.

b.	Remove a passenger from the flight
i.	Choose the seat number to be cancelled.
ii.	Delete the passenger’s name.
iii.	If the waiting list is empty, update the array so the seat is available
iv.	If the waiting list is not empty, remove the first person from the list, and give him or her newly vacated seat.
3.	Show message when
c.	“Book” is pressed but no passenger name, and seat is specified.
d.	“Book” is pressed when an already booked seat is chosen.
e.	“Add to Waiting List” is pressed when there are seats available.
f.	“Cancel” is pressed without specifying the seat.
g.	After successfully booking.
h.	After successfully cancelling a seat.
i.	After successfully adding to waiting list.

2.	Add a “Fill All” button. Clicking this button will fill all the 15 seats. You may use the same passenger name for all seats.
3.	You must use arrays for seats and waiting list. No collection (e.g., ArrayList or ListBox except the list boxes to show row and column-see the diagram below) is allowed.
