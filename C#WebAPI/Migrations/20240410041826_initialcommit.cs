using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioNoIdentityAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialcommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortairLogistixContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailMessage = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EmailSent = table.Column<bool>(type: "bit", nullable: false),
                    DateInsertedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortairLogistixContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailMessage = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EmailSent = table.Column<bool>(type: "bit", nullable: false),
                    DateInsertedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TroubleshootingService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TroubleshootingService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TroubleshootingCustomerIssues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EmailSent = table.Column<bool>(type: "bit", nullable: false),
                    TicketID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueSelected = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DateInsertedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    TroubleshootingServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TroubleshootingCustomerIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TroubleshootingCustomerIssues_TroubleshootingService_TroubleshootingServicesId",
                        column: x => x.TroubleshootingServicesId,
                        principalTable: "TroubleshootingService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TroubleshootingServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TroubleshootingServiceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TroubleshootingServiceTypes_TroubleshootingService_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "TroubleshootingService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "TroubleshootingService",
                columns: new[] { "Id", "ServiceName" },
                values: new object[,]
                {
                    { 1, "TV" },
                    { 2, "Internet" },
                    { 3, "Phone" },
                    { 4, "Mobile" }
                });

            migrationBuilder.InsertData(
                table: "TroubleshootingServiceTypes",
                columns: new[] { "Id", "ServiceId", "ServiceTypeDescription" },
                values: new object[,]
                {
                    { 1, 1, "\"{\\r\\n    \\\"No Audio\\\": [\\r\\n        \\\"Check HDMI cord and replace it if damaged.\\\",\\r\\n        \\\"Check to make sure power cord is plugged into a working outlet.\\\",\\r\\n        \\\"Change your power adapter (if available).\\\",\\r\\n        \\\"Check to ensure the cable connections (HDMI, RCA cable) between the set-top box and TV are properly connected.\\\",\\r\\n        \\\"Check coax cable at the rear of the device and ensure it is securely attached.\\\",\\r\\n        \\\"Check volume on the TV device itself and using the remote to make sure it is not turned down or on mute.\\\",\\r\\n        \\\"Ensure the batteries are secured properly and working.\\\",\\r\\n        \\\"Perform a remote test! Point your cellular phone towards the top of the remote >Press any of the buttons to see if there is a light showing on the phone (this will check the infrared sensor).\\\",\\r\\n        \\\"Check if the issue persists on other channels, inputs, secondary remotes, or on a secondary set-top box (if available) to verify if it is a general issue.\\\",\\r\\n        \\\"Complete a power cycle (power off then turn on).\\\"\\r\\n    ],\\r\\n    \\\"Set-Top Box Not Turning on\\\": [\\r\\n        \\\"Check to make sure power cord is plugged into a working outlet.\\\",\\r\\n        \\\"Change your power adapter (if available).\\\",\\r\\n        \\\"Check to ensure the sensor is not blocked and that you are standing directly in front of the set-top box when using the remote.\\\",\\r\\n        \\\"If the issue persists try using secondary remotes, or on a secondary set-top box (if available) to verify if it is a general issue.\\\"\\r\\n    ],\\r\\n    \\\"Grainy, Pixelated\\\": [\\r\\n        \\\"Check HDMI cord and replace it if damaged.\\\",\\r\\n        \\\"Check to ensure the cable connections (HDMI, RCA cable) between the set-top box and TV are properly connected.\\\",\\r\\n        \\\"Check coax cable at the rear of the device and ensure it is securely attached.\\\",\\r\\n        \\\"Check if the issue persists on other channels to verify if it is a general issue.\\\"\\r\\n    ],\\r\\n    \\\"Blank Screen\\\": [\\r\\n        \\\"Check HDMI cord and replace it if damaged.\\\",\\r\\n        \\\"Check to make sure power cord is plugged into a working outlet.\\\",\\r\\n        \\\"Change your power adapter (if available).\\\",\\r\\n        \\\"Check to ensure the cable connections (HDMI, RCA cable) between the set-top box and TV are properly connected.\\\",\\r\\n        \\\"Check coax cable at the rear of the device and ensure it is securely attached.\\\",\\r\\n        \\\"Complete a channel scan. Press Menu > scroll to across to configuration > scroll down to system settings > select channel installation > select manual channel installation > enter 555 start frequency / and 765 end frequency > Press start > once completed Press Save.\\\",\\r\\n        \\\"Check if the issue persists on other channels, inputs, secondary remotes, or on a secondary set-top box (if available) to verify if it is a general issue.\\\",\\r\\n        \\\"Complete a power cycle (power off then turn on).\\\"\\r\\n    ],\\r\\n    \\\"No Signal or Low Signal\\\": [\\r\\n        \\\"Check HDMI cord and replace it if damaged.\\\",\\r\\n        \\\"Check to make sure power cord is plugged into a working outlet.\\\",\\r\\n        \\\"Change your power adapter (if available).\\\",\\r\\n        \\\"Check to ensure the cable connections (HDMI, RCA cable) between the set-top box and TV are properly connected.\\\",\\r\\n        \\\"Check coax cable at the rear of the device and ensure it is securely attached.\\\",\\r\\n        \\\"Check volume on the TV device itself and using the remote to make sure it is not turned down or on mute.\\\",\\r\\n        \\\"Ensure the batteries are secured properly and working.\\\",\\r\\n        \\\"Perform a remote test! Point your cellular phone towards the top of the remote >Press any of the buttons to see if there is a light showing on the phone (this will check the infrared sensor).\\\",\\r\\n        \\\"Check if the issue persists on other channels, inputs, secondary remotes, or on a secondary set-top box (if available) to verify if it is a general issue.\\\",\\r\\n        \\\"Complete a power cycle (power off then turn on).\\\"\\r\\n    ],\\r\\n    \\\"Missing Channel(s)\\\": [\\r\\n        \\\"Check to see if the channel is included in your subscription package.\\\",\\r\\n        \\\"If channel related, complete a channel scan. Press Menu > scroll to across to configuration > scroll down to system settings > select channel installation > select manual channel installation > enter 555 start frequency / and 765 end frequency > Press start > once completed Press Save.\\\",\\r\\n        \\\"If the issue persists try using secondary remotes, or on a secondary set-top box (if available) to verify if it is a general issue.\\\",\\r\\n        \\\"Complete a power cycle (power off then turn on).\\\"\\r\\n    ],\\r\\n    \\\"Channels not Loading or Populating\\\": [\\r\\n        \\\"Press the menu button on the remote ---> Go to Favorites option. There are three options available HDTV, TV and Radio ---> scroll and select TV access the guide there. All channels including SD and HD channels should now be populated.\\\",\\r\\n        \\\"If the issue persists, complete a power cycle (power off then turn on).\\\"\\r\\n    ],\\r\\n    \\\"Channels Guide Grayed Out\\\": [\\r\\n        \\\"Check if set top has an IP address via the Network Settings.\\\",\\r\\n        \\\"Ensure that an Ethernet cable is not plugged in from modem to set top box as well.\\\",\\r\\n        \\\"If no IP Address is present, complete a reset of the modem.\\\",\\r\\n        \\\"Once the modem comes online completed a menu restart from the set top box. This is done by going to Menu>Configuration>System Settings>restart device. Once the set top box reboots an IP address and channel guide should be now be visible.\\\"\\r\\n    ],\\r\\n    \\\"No Access '0'\\\": [\\r\\n        \\\"Check HDMI cord and replace it if damaged.\\\",\\r\\n        \\\"Check to ensure the cable connections (HDMI, RCA cable) between the set-top box and TV are properly connected.\\\",\\r\\n        \\\"Check if set top has an IP address via the Network Settings.\\\",\\r\\n        \\\"Ensure that an Ethernet cable is not plugged in from modem to set top box as well.\\\",\\r\\n        \\\"If no IP Address is present, complete a reset of the modem.\\\",\\r\\n        \\\"Once the modem comes online completed a menu restart from the set top box. This is done by going to Menu>Configuration>System Settings>restart device. Once the set top box reboots an IP address and channel guide should be now be visible.\\\"\\r\\n    ]\\r\\n  }\"" },
                    { 2, 2, "\"{\\r\\n    \\\"No lights on the Modem\\\": [\\r\\n        \\\"Check the power adapter and confirm if it is plugged into the power outlet.\\\",\\r\\n        \\\"Make sure the power is turned on for the device.\\\",\\r\\n        \\\"Try connecting another device to the power outlet (to see if outlet itself is working).\\\",\\r\\n        \\\"Check to ensure the coaxial connection is secured at the rear of the device.\\\"\\r\\n    ],\\r\\n    \\\"No power\\\": [\\r\\n        \\\"Check the power adapter and confirm if it is plugged into the power outlet.\\\",\\r\\n        \\\"Make sure the power is turned on for the device.\\\",\\r\\n        \\\"Try connecting another device to the power outlet (to see if outlet itself is working).\\\",\\r\\n        \\\"Check to ensure the coaxial connection is secured at the rear of the device.\\\"\\r\\n    ],\\r\\n    \\\"No DS Light on Modem\\\": [\\r\\n        \\\"Check the power adapter and confirm if it is plugged into the power outlet.\\\",\\r\\n        \\\"Make sure the power is turned on for the device.\\\",\\r\\n        \\\"Try connecting another device to the power outlet (to see if outlet itself is working).\\\",\\r\\n        \\\"Check to ensure the coaxial connection is secured at the rear of the device.\\\"\\r\\n    ],\\r\\n    \\\"Poor Wi-Fi Range\\\": [\\r\\n        \\\"Check the modem’s location for obstructions that are physical or electronic such as microwaves and toaster ovens.\\\",\\r\\n        \\\"Ensure the modem is in an elevated position that is at least a foot off the ground.\\\",\\r\\n        \\\"Ensure there is clear line of sight between wireless range extenders.\\\",\\r\\n        \\\"Try connecting another personal device (laptop, cellphone, or tablet).\\\",\\r\\n        \\\"Turn off devices connected to Wi-Fi and not in use.\\\",\\r\\n        \\\"Try browsing using other webpages.\\\",\\r\\n        \\\"Try browsing using a different device.\\\",\\r\\n        \\\"Close some of your apps you are running on the device.\\\",\\r\\n        \\\"Verify that your network is not open to the public. If so, make your network private.\\\",\\r\\n        \\\"Check if you are connected to the network at home.\\\",\\r\\n        \\\"Check connected device settings such as airplane mode or hotspot.\\\",\\r\\n        \\\"Ensure you are using the correct password and check for caps and lowercase.\\\",\\r\\n        \\\"Ensure you are connecting to the correct network address.\\\",\\r\\n        \\\"Check for damage on the outlet and device.\\\",\\r\\n        \\\"Restart the modem.\\\"\\r\\n    ],\\r\\n    \\\"Slow Speed\\\": [\\r\\n        \\\"Check the modem’s location for obstructions that are physical or electronic such as microwaves and toaster ovens.\\\",\\r\\n        \\\"Ensure the modem is in an elevated position that is at least a foot off the ground.\\\",\\r\\n        \\\"Ensure there is clear line of sight between wireless range extenders.\\\",\\r\\n        \\\"Try connecting another personal device (laptop, cellphone, or tablet).\\\",\\r\\n        \\\"Turn off devices connected to Wi-Fi and not in use.\\\",\\r\\n        \\\"Try browsing using other webpages.\\\",\\r\\n        \\\"Try browsing using a different device.\\\",\\r\\n        \\\"Close some of your apps you are running on the device.\\\",\\r\\n        \\\"Verify that your network is not open to the public. If so, make your network private.\\\",\\r\\n        \\\"Check if you are connected to the network at home.\\\",\\r\\n        \\\"Check connected device settings such as airplane mode or hotspot.\\\",\\r\\n        \\\"Ensure you are using the correct password and check for caps and lowercase.\\\",\\r\\n        \\\"Ensure you are connecting to the correct network address.\\\",\\r\\n        \\\"Check for damage on the outlet and device.\\\",\\r\\n        \\\"Restart the modem.\\\"\\r\\n    ],\\r\\n    \\\"Unable to Browse - Home Internet\\\": [\\r\\n        \\\"Check the modem’s location for obstructions that are physical or electronic such as microwaves and toaster ovens.\\\",\\r\\n        \\\"Ensure the modem is in an elevated position that is at least a foot off the ground.\\\",\\r\\n        \\\"Ensure there is clear line of sight between wireless range extenders.\\\",\\r\\n        \\\"Try connecting another personal device (laptop, cellphone, or tablet).\\\",\\r\\n        \\\"Turn off devices connected to Wi-Fi and not in use.\\\",\\r\\n        \\\"Try browsing using other webpages.\\\",\\r\\n        \\\"Try browsing using a different device.\\\",\\r\\n        \\\"Close some of your apps you are running on the device.\\\",\\r\\n        \\\"Verify that your network is not open to the public. If so, make your network private.\\\",\\r\\n        \\\"Check if you are connected to the network at home.\\\",\\r\\n        \\\"Check connected device settings such as airplane mode or hotspot.\\\",\\r\\n        \\\"Ensure you are using the correct password and check for caps and lowercase.\\\",\\r\\n        \\\"Ensure you are connecting to the correct network address.\\\",\\r\\n        \\\"Check for damage on the outlet and device.\\\",\\r\\n        \\\"Restart the modem.\\\"\\r\\n    ],\\r\\n    \\\"Unable to Connect to Wi-Fi\\\": [\\r\\n        \\\"Check the modem’s location for obstructions that are physical or electronic such as microwaves and toaster ovens.\\\",\\r\\n        \\\"Ensure the modem is in an elevated position that is at least a foot off the ground.\\\",\\r\\n        \\\"Ensure there is clear line of sight between wireless range extenders.\\\",\\r\\n        \\\"Try connecting another personal device (laptop, cellphone, or tablet).\\\",\\r\\n        \\\"Turn off devices connected to Wi-Fi and not in use.\\\",\\r\\n        \\\"Try browsing using other webpages.\\\",\\r\\n        \\\"Try browsing using a different device.\\\",\\r\\n        \\\"Close some of your apps you are running on the device.\\\",\\r\\n        \\\"Verify that your network is not open to the public. If so, make your network private.\\\",\\r\\n        \\\"Check if you are connected to the network at home.\\\",\\r\\n        \\\"Check connected device settings such as airplane mode or hotspot.\\\",\\r\\n        \\\"Ensure you are using the correct password and check for caps and lowercase.\\\",\\r\\n        \\\"Ensure you are connecting to the correct network address.\\\",\\r\\n        \\\"Check for damage on the outlet and device.\\\",\\r\\n        \\\"Restart the modem.\\\"\\r\\n    ],\\r\\n    \\\"Intermittent Connection\\\": [\\r\\n        \\\"Check the modem’s location for obstructions that are physical or electronic such as microwaves and toaster ovens.\\\",\\r\\n        \\\"Ensure the modem is in an elevated position that is at least a foot off the ground.\\\",\\r\\n        \\\"Ensure there is clear line of sight between wireless range extenders.\\\",\\r\\n        \\\"Try connecting another personal device (laptop, cellphone, or tablet).\\\",\\r\\n        \\\"Turn off devices connected to Wi-Fi and not in use.\\\",\\r\\n        \\\"Try browsing using other webpages.\\\",\\r\\n        \\\"Try browsing using a different device.\\\",\\r\\n        \\\"Close some of your apps you are running on the device.\\\",\\r\\n        \\\"Verify that your network is not open to the public. If so, make your network private.\\\",\\r\\n        \\\"Check if you are connected to the network at home.\\\",\\r\\n        \\\"Check connected device settings such as airplane mode or hotspot.\\\",\\r\\n        \\\"Ensure you are using the correct password and check for caps and lowercase.\\\",\\r\\n        \\\"Ensure you are connecting to the correct network address.\\\",\\r\\n        \\\"Check for damage on the outlet and device.\\\",\\r\\n        \\\"Restart the modem.\\\"\\r\\n    ],\\r\\n    \\\"General Data Tips\\\":[\\r\\n        {\\r\\n            \\\"0\\\": [\\r\\n                \\\"Ensure you devices such as laptops are not kept in a hibernated state.\\\",\\r\\n                \\\"Ensure there are no obstruction or obstacles that can interfere with the signal.\\\",\\r\\n                \\\"Do not place modem/ router on beds or soft surfaces.\\\",\\r\\n                \\\"Elevate modem and or routers – “the higher the better”.\\\",\\r\\n                \\\"Disconnect unnecessary users connected to the network.\\\",\\r\\n                \\\"High bandwidth consumption applications are to be disconnected/ stopped when not in use.\\\",\\r\\n                \\\"Avoid torrenting.\\\"\\r\\n            ],\\r\\n            \\\"1\\\": [\\r\\n                \\\"Having strong Wi-Fi connectivity throughout your home is important for you to enjoy uninterrupted streaming and gaming sessions, ensuring you are in tune with all the happening on social media or simply just browsing the web. A Wi-Fi range extender or Booster allows for the optimal digital experience.\\\"\\r\\n            ]\\r\\n        }\\r\\n    ]\\r\\n}\"" },
                    { 3, 3, "\"{\\r\\n    \\\"No Dial Tone\\\" : [\\r\\n        \\\"Check that any cords are properly connected on both ends to the wall and phone\\\",\\r\\n        \\\"If using a cordless phone, check if it is charged\\\",\\r\\n        \\\"If the issue persists, try using a shorter cord between the wall jack and phone\\\",\\r\\n        \\\"Reset the modem by pressing and holding down the reset button on the device for 20-30 seconds before releasing\\\",\\r\\n        \\\"Try connecting to the secondary telephone port to the rear of the modem\\\"\\r\\n    ],\\r\\n    \\\"Cannot Hear\\\": [\\r\\n        \\\"Check that any cords are properly connected on both ends to the wall and phone\\\",\\r\\n        \\\"If using a cordless phone, check if it is charged\\\",\\r\\n        \\\"Restart the phone by unplugging the base from the power outlet and plug it back in after 30 seconds\\\",\\r\\n        \\\"Try placing a test call from the device\\\",\\r\\n        \\\"If the issue persists, try using a shorter cord between the wall jack and phone\\\"\\r\\n    ],\\r\\n    \\\"Static or Irregular Noises on the Line\\\": [\\r\\n        \\\"Check that any cords are properly connected on both ends to the wall and phone/ phone base\\\",\\r\\n        \\\"If using a cordless phone, check if it is charged\\\",\\r\\n        \\\"If using a corded phone, check for cracks and peeling of the plastic coating\\\",\\r\\n        \\\"Check that the modem not located next to, beneath or on top of any other electronic devices or appliances\\\",\\r\\n        \\\"If the issue persists, try using a shorter cord between the wall jack and phone\\\"\\r\\n    ],\\r\\n    \\\"Beeping on the line\\\": [\\r\\n        \\\"Check your settings to see if the phone is set to “pulse”. If so, switch your settings to “tone”.\\\",\\r\\n        \\\"If the issue persists, try unplugging the phone/ phone base from modem/wall outlet for 30 seconds before plugging it back in\\\",\\r\\n        \\\"If available, try connecting a different phone.\\\",\\r\\n        \\\"If the issue is resolved the first device is faulty and needs to be switched.\\\"\\r\\n\\r\\n    ],\\r\\n    \\\"Unable to Receive Calls - Home Phone\\\": [\\r\\n        \\\"Check your account to see if your bill is up to date. If not, your service is likely disconnected. Clear your balance and reconnect your account to resolve the issue.\\\",\\r\\n        \\\"Verify that you can make calls by completing a test call\\\",\\r\\n        \\\"If your account is up to date, and you can make but not receive calls, technical support is needed\\\"\\r\\n    ],\\r\\n    \\\"Unable to Make Calls - Home Phone\\\":[\\r\\n        \\\"Check your account to see if your bill is up to date. If not, your service is likely disconnected. Clear your balance and reconnect your account to resolve the issue.\\\",\\r\\n        \\\"Verify that you can receive calls by dialing your landline through a different device.\\\",\\r\\n        \\\"If your account is up to date, and you can receive but not make calls, technical support is needed\\\"\\r\\n    ],\\r\\n    \\\"Caller ID not Displayed\\\":[\\r\\n        \\\"Check to ensure you are subscribed to the caller ID feature\\\",\\r\\n        \\\"Check that any cords are properly connected on both ends to the wall and phone/ phone base\\\",\\r\\n        \\\"Check to ensure you have not activated the Call Forwarding feature\\\"\\r\\n    ]\\r\\n}\"" },
                    { 4, 4, "\"{\\r\\n    \\\"Unable to Make Calls - Mobile\\\": [\\r\\n        \\\"Verify that you are subscribed to the service you are trying to use (i.e. roaming plan, data plan).\\\",\\r\\n        \\\"Make sure the mobile data feature on the device is turned on.\\\",\\r\\n        \\\"Check to make sure Flow supports the action being requested.\\\",\\r\\n        \\\"If the issue persists, turn on airplane mode for 15 seconds, then turn it back off.\\\",\\r\\n        \\\"Perform a device restart.\\\",\\r\\n        \\\"Remove SIM card from the device, wipe it with a dry cloth or pencil eraser, then reinsert and try again.\\\",\\r\\n        \\\"Check to ensure you have Flow SIM card.\\\"\\r\\n    ],\\r\\n    \\\"Unable to Browse - Mobile\\\": [\\r\\n        \\\"Verify that you are subscribed to the service you are trying to use (i.e. roaming plan, data plan).\\\",\\r\\n        \\\"Make sure the mobile data feature on the device is turned on.\\\",\\r\\n        \\\"Check to make sure Flow supports the action being requested.\\\",\\r\\n        \\\"If the issue persists, turn on airplane mode for 15 seconds, then turn it back off.\\\",\\r\\n        \\\"Perform a device restart.\\\",\\r\\n        \\\"Remove SIM card from the device, wipe it with a dry cloth or pencil eraser, then reinsert and try again.\\\",\\r\\n        \\\"Check to ensure you have Flow SIM card.\\\"\\r\\n    ],\\r\\n    \\\"Unable to Make and/or Receive Calls\\\": [\\r\\n        \\\"Verify that you are subscribed to the service you are trying to use (i.e. roaming plan, data plan).\\\",\\r\\n        \\\"Make sure the mobile data feature on the device is turned on.\\\",\\r\\n        \\\"Check to make sure Flow supports the action being requested.\\\",\\r\\n        \\\"If the issue persists, turn on airplane mode for 15 seconds, then turn it back off.\\\",\\r\\n        \\\"Perform a device restart.\\\",\\r\\n        \\\"Remove SIM card from the device, wipe it with a dry cloth or pencil eraser, then reinsert and try again.\\\",\\r\\n        \\\"Check to ensure you have Flow SIM card.\\\"\\r\\n    ],\\r\\n    \\\"Unable to Send and/or Receive SMS\\\": [\\r\\n        \\\"Verify that you are subscribed to the service you are trying to use.\\\",\\r\\n        \\\"Make sure the mobile data feature on the device is turned on.\\\",\\r\\n        \\\"Check to make sure Flow supports the action being requested.\\\",\\r\\n        \\\"If the issue persists, turn on airplane mode for 15 seconds, then turn it back off.\\\",\\r\\n        \\\"Perform a device restart.\\\",\\r\\n        \\\"Remove SIM card from the device, wipe it with a dry cloth or pencil eraser, then reinsert and try again.\\\",\\r\\n        \\\"Check to ensure you have Flow SIM card.\\\"\\r\\n    ],\\r\\n    \\\"Credit Not Showing Up\\\": [\\r\\n\\r\\n    ],\\r\\n    \\\"Unable to Receive Calls - Mobile\\\": [\\r\\n\\r\\n    ],\\r\\n    \\\"Activating Roaming\\\": [\\r\\n\\r\\n    ],\\r\\n    \\\"Mobile Data Not Working\\\": [\\r\\n\\r\\n    ],\\r\\n    \\\"General Mobile Tips\\\": [\\r\\n\\r\\n    ]\\r\\n}\"" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TroubleshootingCustomerIssues_TroubleshootingServicesId",
                table: "TroubleshootingCustomerIssues",
                column: "TroubleshootingServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_TroubleshootingServiceTypes_ServiceId",
                table: "TroubleshootingServiceTypes",
                column: "ServiceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortairLogistixContacts");

            migrationBuilder.DropTable(
                name: "PortfolioContacts");

            migrationBuilder.DropTable(
                name: "TroubleshootingCustomerIssues");

            migrationBuilder.DropTable(
                name: "TroubleshootingServiceTypes");

            migrationBuilder.DropTable(
                name: "TroubleshootingService");
        }
    }
}
