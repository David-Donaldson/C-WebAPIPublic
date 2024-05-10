﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfolioNoIdentityAPI.Data;

#nullable disable

namespace PortfolioNoIdentityAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PortfolioNoIdentityAPI.Models.PortairLogistixContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateInsertedTimestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailMessage")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailSent")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PortairLogistixContacts");
                });

            modelBuilder.Entity("PortfolioNoIdentityAPI.Models.PortfolioContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateInsertedTimestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailMessage")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailSent")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PortfolioContacts");
                });

            modelBuilder.Entity("PortfolioNoIdentityAPI.Models.TroubleshootingCustomerIssue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateInsertedTimestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("EmailSent")
                        .HasColumnType("bit");

                    b.Property<string>("IssueSelected")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("TicketID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TroubleshootingServicesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TroubleshootingServicesId");

                    b.ToTable("TroubleshootingCustomerIssues");
                });

            modelBuilder.Entity("PortfolioNoIdentityAPI.Models.TroubleshootingService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TroubleshootingService", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ServiceName = "TV"
                        },
                        new
                        {
                            Id = 2,
                            ServiceName = "Internet"
                        },
                        new
                        {
                            Id = 3,
                            ServiceName = "Phone"
                        },
                        new
                        {
                            Id = 4,
                            ServiceName = "Mobile"
                        });
                });

            modelBuilder.Entity("PortfolioNoIdentityAPI.Models.TroubleshootingServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId")
                        .IsUnique();

                    b.ToTable("TroubleshootingServiceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ServiceId = 1,
                            ServiceTypeDescription = "\"{\\r\\n    \\\"No Audio\\\": [\\r\\n        \\\"Check HDMI cord and replace it if damaged.\\\",\\r\\n        \\\"Check to make sure power cord is plugged into a working outlet.\\\",\\r\\n        \\\"Change your power adapter (if available).\\\",\\r\\n        \\\"Check to ensure the cable connections (HDMI, RCA cable) between the set-top box and TV are properly connected.\\\",\\r\\n        \\\"Check coax cable at the rear of the device and ensure it is securely attached.\\\",\\r\\n        \\\"Check volume on the TV device itself and using the remote to make sure it is not turned down or on mute.\\\",\\r\\n        \\\"Ensure the batteries are secured properly and working.\\\",\\r\\n        \\\"Perform a remote test! Point your cellular phone towards the top of the remote >Press any of the buttons to see if there is a light showing on the phone (this will check the infrared sensor).\\\",\\r\\n        \\\"Check if the issue persists on other channels, inputs, secondary remotes, or on a secondary set-top box (if available) to verify if it is a general issue.\\\",\\r\\n        \\\"Complete a power cycle (power off then turn on).\\\"\\r\\n    ],\\r\\n    \\\"Set-Top Box Not Turning on\\\": [\\r\\n        \\\"Check to make sure power cord is plugged into a working outlet.\\\",\\r\\n        \\\"Change your power adapter (if available).\\\",\\r\\n        \\\"Check to ensure the sensor is not blocked and that you are standing directly in front of the set-top box when using the remote.\\\",\\r\\n        \\\"If the issue persists try using secondary remotes, or on a secondary set-top box (if available) to verify if it is a general issue.\\\"\\r\\n    ],\\r\\n    \\\"Grainy, Pixelated\\\": [\\r\\n        \\\"Check HDMI cord and replace it if damaged.\\\",\\r\\n        \\\"Check to ensure the cable connections (HDMI, RCA cable) between the set-top box and TV are properly connected.\\\",\\r\\n        \\\"Check coax cable at the rear of the device and ensure it is securely attached.\\\",\\r\\n        \\\"Check if the issue persists on other channels to verify if it is a general issue.\\\"\\r\\n    ],\\r\\n    \\\"Blank Screen\\\": [\\r\\n        \\\"Check HDMI cord and replace it if damaged.\\\",\\r\\n        \\\"Check to make sure power cord is plugged into a working outlet.\\\",\\r\\n        \\\"Change your power adapter (if available).\\\",\\r\\n        \\\"Check to ensure the cable connections (HDMI, RCA cable) between the set-top box and TV are properly connected.\\\",\\r\\n        \\\"Check coax cable at the rear of the device and ensure it is securely attached.\\\",\\r\\n        \\\"Complete a channel scan. Press Menu > scroll to across to configuration > scroll down to system settings > select channel installation > select manual channel installation > enter 555 start frequency / and 765 end frequency > Press start > once completed Press Save.\\\",\\r\\n        \\\"Check if the issue persists on other channels, inputs, secondary remotes, or on a secondary set-top box (if available) to verify if it is a general issue.\\\",\\r\\n        \\\"Complete a power cycle (power off then turn on).\\\"\\r\\n    ],\\r\\n    \\\"No Signal or Low Signal\\\": [\\r\\n        \\\"Check HDMI cord and replace it if damaged.\\\",\\r\\n        \\\"Check to make sure power cord is plugged into a working outlet.\\\",\\r\\n        \\\"Change your power adapter (if available).\\\",\\r\\n        \\\"Check to ensure the cable connections (HDMI, RCA cable) between the set-top box and TV are properly connected.\\\",\\r\\n        \\\"Check coax cable at the rear of the device and ensure it is securely attached.\\\",\\r\\n        \\\"Check volume on the TV device itself and using the remote to make sure it is not turned down or on mute.\\\",\\r\\n        \\\"Ensure the batteries are secured properly and working.\\\",\\r\\n        \\\"Perform a remote test! Point your cellular phone towards the top of the remote >Press any of the buttons to see if there is a light showing on the phone (this will check the infrared sensor).\\\",\\r\\n        \\\"Check if the issue persists on other channels, inputs, secondary remotes, or on a secondary set-top box (if available) to verify if it is a general issue.\\\",\\r\\n        \\\"Complete a power cycle (power off then turn on).\\\"\\r\\n    ],\\r\\n    \\\"Missing Channel(s)\\\": [\\r\\n        \\\"Check to see if the channel is included in your subscription package.\\\",\\r\\n        \\\"If channel related, complete a channel scan. Press Menu > scroll to across to configuration > scroll down to system settings > select channel installation > select manual channel installation > enter 555 start frequency / and 765 end frequency > Press start > once completed Press Save.\\\",\\r\\n        \\\"If the issue persists try using secondary remotes, or on a secondary set-top box (if available) to verify if it is a general issue.\\\",\\r\\n        \\\"Complete a power cycle (power off then turn on).\\\"\\r\\n    ],\\r\\n    \\\"Channels not Loading or Populating\\\": [\\r\\n        \\\"Press the menu button on the remote ---> Go to Favorites option. There are three options available HDTV, TV and Radio ---> scroll and select TV access the guide there. All channels including SD and HD channels should now be populated.\\\",\\r\\n        \\\"If the issue persists, complete a power cycle (power off then turn on).\\\"\\r\\n    ],\\r\\n    \\\"Channels Guide Grayed Out\\\": [\\r\\n        \\\"Check if set top has an IP address via the Network Settings.\\\",\\r\\n        \\\"Ensure that an Ethernet cable is not plugged in from modem to set top box as well.\\\",\\r\\n        \\\"If no IP Address is present, complete a reset of the modem.\\\",\\r\\n        \\\"Once the modem comes online completed a menu restart from the set top box. This is done by going to Menu>Configuration>System Settings>restart device. Once the set top box reboots an IP address and channel guide should be now be visible.\\\"\\r\\n    ],\\r\\n    \\\"No Access '0'\\\": [\\r\\n        \\\"Check HDMI cord and replace it if damaged.\\\",\\r\\n        \\\"Check to ensure the cable connections (HDMI, RCA cable) between the set-top box and TV are properly connected.\\\",\\r\\n        \\\"Check if set top has an IP address via the Network Settings.\\\",\\r\\n        \\\"Ensure that an Ethernet cable is not plugged in from modem to set top box as well.\\\",\\r\\n        \\\"If no IP Address is present, complete a reset of the modem.\\\",\\r\\n        \\\"Once the modem comes online completed a menu restart from the set top box. This is done by going to Menu>Configuration>System Settings>restart device. Once the set top box reboots an IP address and channel guide should be now be visible.\\\"\\r\\n    ]\\r\\n  }\""
                        },
                        new
                        {
                            Id = 2,
                            ServiceId = 2,
                            ServiceTypeDescription = "\"{\\r\\n    \\\"No lights on the Modem\\\": [\\r\\n        \\\"Check the power adapter and confirm if it is plugged into the power outlet.\\\",\\r\\n        \\\"Make sure the power is turned on for the device.\\\",\\r\\n        \\\"Try connecting another device to the power outlet (to see if outlet itself is working).\\\",\\r\\n        \\\"Check to ensure the coaxial connection is secured at the rear of the device.\\\"\\r\\n    ],\\r\\n    \\\"No power\\\": [\\r\\n        \\\"Check the power adapter and confirm if it is plugged into the power outlet.\\\",\\r\\n        \\\"Make sure the power is turned on for the device.\\\",\\r\\n        \\\"Try connecting another device to the power outlet (to see if outlet itself is working).\\\",\\r\\n        \\\"Check to ensure the coaxial connection is secured at the rear of the device.\\\"\\r\\n    ],\\r\\n    \\\"No DS Light on Modem\\\": [\\r\\n        \\\"Check the power adapter and confirm if it is plugged into the power outlet.\\\",\\r\\n        \\\"Make sure the power is turned on for the device.\\\",\\r\\n        \\\"Try connecting another device to the power outlet (to see if outlet itself is working).\\\",\\r\\n        \\\"Check to ensure the coaxial connection is secured at the rear of the device.\\\"\\r\\n    ],\\r\\n    \\\"Poor Wi-Fi Range\\\": [\\r\\n        \\\"Check the modem’s location for obstructions that are physical or electronic such as microwaves and toaster ovens.\\\",\\r\\n        \\\"Ensure the modem is in an elevated position that is at least a foot off the ground.\\\",\\r\\n        \\\"Ensure there is clear line of sight between wireless range extenders.\\\",\\r\\n        \\\"Try connecting another personal device (laptop, cellphone, or tablet).\\\",\\r\\n        \\\"Turn off devices connected to Wi-Fi and not in use.\\\",\\r\\n        \\\"Try browsing using other webpages.\\\",\\r\\n        \\\"Try browsing using a different device.\\\",\\r\\n        \\\"Close some of your apps you are running on the device.\\\",\\r\\n        \\\"Verify that your network is not open to the public. If so, make your network private.\\\",\\r\\n        \\\"Check if you are connected to the network at home.\\\",\\r\\n        \\\"Check connected device settings such as airplane mode or hotspot.\\\",\\r\\n        \\\"Ensure you are using the correct password and check for caps and lowercase.\\\",\\r\\n        \\\"Ensure you are connecting to the correct network address.\\\",\\r\\n        \\\"Check for damage on the outlet and device.\\\",\\r\\n        \\\"Restart the modem.\\\"\\r\\n    ],\\r\\n    \\\"Slow Speed\\\": [\\r\\n        \\\"Check the modem’s location for obstructions that are physical or electronic such as microwaves and toaster ovens.\\\",\\r\\n        \\\"Ensure the modem is in an elevated position that is at least a foot off the ground.\\\",\\r\\n        \\\"Ensure there is clear line of sight between wireless range extenders.\\\",\\r\\n        \\\"Try connecting another personal device (laptop, cellphone, or tablet).\\\",\\r\\n        \\\"Turn off devices connected to Wi-Fi and not in use.\\\",\\r\\n        \\\"Try browsing using other webpages.\\\",\\r\\n        \\\"Try browsing using a different device.\\\",\\r\\n        \\\"Close some of your apps you are running on the device.\\\",\\r\\n        \\\"Verify that your network is not open to the public. If so, make your network private.\\\",\\r\\n        \\\"Check if you are connected to the network at home.\\\",\\r\\n        \\\"Check connected device settings such as airplane mode or hotspot.\\\",\\r\\n        \\\"Ensure you are using the correct password and check for caps and lowercase.\\\",\\r\\n        \\\"Ensure you are connecting to the correct network address.\\\",\\r\\n        \\\"Check for damage on the outlet and device.\\\",\\r\\n        \\\"Restart the modem.\\\"\\r\\n    ],\\r\\n    \\\"Unable to Browse - Home Internet\\\": [\\r\\n        \\\"Check the modem’s location for obstructions that are physical or electronic such as microwaves and toaster ovens.\\\",\\r\\n        \\\"Ensure the modem is in an elevated position that is at least a foot off the ground.\\\",\\r\\n        \\\"Ensure there is clear line of sight between wireless range extenders.\\\",\\r\\n        \\\"Try connecting another personal device (laptop, cellphone, or tablet).\\\",\\r\\n        \\\"Turn off devices connected to Wi-Fi and not in use.\\\",\\r\\n        \\\"Try browsing using other webpages.\\\",\\r\\n        \\\"Try browsing using a different device.\\\",\\r\\n        \\\"Close some of your apps you are running on the device.\\\",\\r\\n        \\\"Verify that your network is not open to the public. If so, make your network private.\\\",\\r\\n        \\\"Check if you are connected to the network at home.\\\",\\r\\n        \\\"Check connected device settings such as airplane mode or hotspot.\\\",\\r\\n        \\\"Ensure you are using the correct password and check for caps and lowercase.\\\",\\r\\n        \\\"Ensure you are connecting to the correct network address.\\\",\\r\\n        \\\"Check for damage on the outlet and device.\\\",\\r\\n        \\\"Restart the modem.\\\"\\r\\n    ],\\r\\n    \\\"Unable to Connect to Wi-Fi\\\": [\\r\\n        \\\"Check the modem’s location for obstructions that are physical or electronic such as microwaves and toaster ovens.\\\",\\r\\n        \\\"Ensure the modem is in an elevated position that is at least a foot off the ground.\\\",\\r\\n        \\\"Ensure there is clear line of sight between wireless range extenders.\\\",\\r\\n        \\\"Try connecting another personal device (laptop, cellphone, or tablet).\\\",\\r\\n        \\\"Turn off devices connected to Wi-Fi and not in use.\\\",\\r\\n        \\\"Try browsing using other webpages.\\\",\\r\\n        \\\"Try browsing using a different device.\\\",\\r\\n        \\\"Close some of your apps you are running on the device.\\\",\\r\\n        \\\"Verify that your network is not open to the public. If so, make your network private.\\\",\\r\\n        \\\"Check if you are connected to the network at home.\\\",\\r\\n        \\\"Check connected device settings such as airplane mode or hotspot.\\\",\\r\\n        \\\"Ensure you are using the correct password and check for caps and lowercase.\\\",\\r\\n        \\\"Ensure you are connecting to the correct network address.\\\",\\r\\n        \\\"Check for damage on the outlet and device.\\\",\\r\\n        \\\"Restart the modem.\\\"\\r\\n    ],\\r\\n    \\\"Intermittent Connection\\\": [\\r\\n        \\\"Check the modem’s location for obstructions that are physical or electronic such as microwaves and toaster ovens.\\\",\\r\\n        \\\"Ensure the modem is in an elevated position that is at least a foot off the ground.\\\",\\r\\n        \\\"Ensure there is clear line of sight between wireless range extenders.\\\",\\r\\n        \\\"Try connecting another personal device (laptop, cellphone, or tablet).\\\",\\r\\n        \\\"Turn off devices connected to Wi-Fi and not in use.\\\",\\r\\n        \\\"Try browsing using other webpages.\\\",\\r\\n        \\\"Try browsing using a different device.\\\",\\r\\n        \\\"Close some of your apps you are running on the device.\\\",\\r\\n        \\\"Verify that your network is not open to the public. If so, make your network private.\\\",\\r\\n        \\\"Check if you are connected to the network at home.\\\",\\r\\n        \\\"Check connected device settings such as airplane mode or hotspot.\\\",\\r\\n        \\\"Ensure you are using the correct password and check for caps and lowercase.\\\",\\r\\n        \\\"Ensure you are connecting to the correct network address.\\\",\\r\\n        \\\"Check for damage on the outlet and device.\\\",\\r\\n        \\\"Restart the modem.\\\"\\r\\n    ],\\r\\n    \\\"General Data Tips\\\":[\\r\\n        {\\r\\n            \\\"0\\\": [\\r\\n                \\\"Ensure you devices such as laptops are not kept in a hibernated state.\\\",\\r\\n                \\\"Ensure there are no obstruction or obstacles that can interfere with the signal.\\\",\\r\\n                \\\"Do not place modem/ router on beds or soft surfaces.\\\",\\r\\n                \\\"Elevate modem and or routers – “the higher the better”.\\\",\\r\\n                \\\"Disconnect unnecessary users connected to the network.\\\",\\r\\n                \\\"High bandwidth consumption applications are to be disconnected/ stopped when not in use.\\\",\\r\\n                \\\"Avoid torrenting.\\\"\\r\\n            ],\\r\\n            \\\"1\\\": [\\r\\n                \\\"Having strong Wi-Fi connectivity throughout your home is important for you to enjoy uninterrupted streaming and gaming sessions, ensuring you are in tune with all the happening on social media or simply just browsing the web. A Wi-Fi range extender or Booster allows for the optimal digital experience.\\\"\\r\\n            ]\\r\\n        }\\r\\n    ]\\r\\n}\""
                        },
                        new
                        {
                            Id = 3,
                            ServiceId = 3,
                            ServiceTypeDescription = "\"{\\r\\n    \\\"No Dial Tone\\\" : [\\r\\n        \\\"Check that any cords are properly connected on both ends to the wall and phone\\\",\\r\\n        \\\"If using a cordless phone, check if it is charged\\\",\\r\\n        \\\"If the issue persists, try using a shorter cord between the wall jack and phone\\\",\\r\\n        \\\"Reset the modem by pressing and holding down the reset button on the device for 20-30 seconds before releasing\\\",\\r\\n        \\\"Try connecting to the secondary telephone port to the rear of the modem\\\"\\r\\n    ],\\r\\n    \\\"Cannot Hear\\\": [\\r\\n        \\\"Check that any cords are properly connected on both ends to the wall and phone\\\",\\r\\n        \\\"If using a cordless phone, check if it is charged\\\",\\r\\n        \\\"Restart the phone by unplugging the base from the power outlet and plug it back in after 30 seconds\\\",\\r\\n        \\\"Try placing a test call from the device\\\",\\r\\n        \\\"If the issue persists, try using a shorter cord between the wall jack and phone\\\"\\r\\n    ],\\r\\n    \\\"Static or Irregular Noises on the Line\\\": [\\r\\n        \\\"Check that any cords are properly connected on both ends to the wall and phone/ phone base\\\",\\r\\n        \\\"If using a cordless phone, check if it is charged\\\",\\r\\n        \\\"If using a corded phone, check for cracks and peeling of the plastic coating\\\",\\r\\n        \\\"Check that the modem not located next to, beneath or on top of any other electronic devices or appliances\\\",\\r\\n        \\\"If the issue persists, try using a shorter cord between the wall jack and phone\\\"\\r\\n    ],\\r\\n    \\\"Beeping on the line\\\": [\\r\\n        \\\"Check your settings to see if the phone is set to “pulse”. If so, switch your settings to “tone”.\\\",\\r\\n        \\\"If the issue persists, try unplugging the phone/ phone base from modem/wall outlet for 30 seconds before plugging it back in\\\",\\r\\n        \\\"If available, try connecting a different phone.\\\",\\r\\n        \\\"If the issue is resolved the first device is faulty and needs to be switched.\\\"\\r\\n\\r\\n    ],\\r\\n    \\\"Unable to Receive Calls - Home Phone\\\": [\\r\\n        \\\"Check your account to see if your bill is up to date. If not, your service is likely disconnected. Clear your balance and reconnect your account to resolve the issue.\\\",\\r\\n        \\\"Verify that you can make calls by completing a test call\\\",\\r\\n        \\\"If your account is up to date, and you can make but not receive calls, technical support is needed\\\"\\r\\n    ],\\r\\n    \\\"Unable to Make Calls - Home Phone\\\":[\\r\\n        \\\"Check your account to see if your bill is up to date. If not, your service is likely disconnected. Clear your balance and reconnect your account to resolve the issue.\\\",\\r\\n        \\\"Verify that you can receive calls by dialing your landline through a different device.\\\",\\r\\n        \\\"If your account is up to date, and you can receive but not make calls, technical support is needed\\\"\\r\\n    ],\\r\\n    \\\"Caller ID not Displayed\\\":[\\r\\n        \\\"Check to ensure you are subscribed to the caller ID feature\\\",\\r\\n        \\\"Check that any cords are properly connected on both ends to the wall and phone/ phone base\\\",\\r\\n        \\\"Check to ensure you have not activated the Call Forwarding feature\\\"\\r\\n    ]\\r\\n}\""
                        },
                        new
                        {
                            Id = 4,
                            ServiceId = 4,
                            ServiceTypeDescription = "\"{\\r\\n    \\\"Unable to Make Calls - Mobile\\\": [\\r\\n        \\\"Verify that you are subscribed to the service you are trying to use (i.e. roaming plan, data plan).\\\",\\r\\n        \\\"Make sure the mobile data feature on the device is turned on.\\\",\\r\\n        \\\"Check to make sure Flow supports the action being requested.\\\",\\r\\n        \\\"If the issue persists, turn on airplane mode for 15 seconds, then turn it back off.\\\",\\r\\n        \\\"Perform a device restart.\\\",\\r\\n        \\\"Remove SIM card from the device, wipe it with a dry cloth or pencil eraser, then reinsert and try again.\\\",\\r\\n        \\\"Check to ensure you have Flow SIM card.\\\"\\r\\n    ],\\r\\n    \\\"Unable to Browse - Mobile\\\": [\\r\\n        \\\"Verify that you are subscribed to the service you are trying to use (i.e. roaming plan, data plan).\\\",\\r\\n        \\\"Make sure the mobile data feature on the device is turned on.\\\",\\r\\n        \\\"Check to make sure Flow supports the action being requested.\\\",\\r\\n        \\\"If the issue persists, turn on airplane mode for 15 seconds, then turn it back off.\\\",\\r\\n        \\\"Perform a device restart.\\\",\\r\\n        \\\"Remove SIM card from the device, wipe it with a dry cloth or pencil eraser, then reinsert and try again.\\\",\\r\\n        \\\"Check to ensure you have Flow SIM card.\\\"\\r\\n    ],\\r\\n    \\\"Unable to Make and/or Receive Calls\\\": [\\r\\n        \\\"Verify that you are subscribed to the service you are trying to use (i.e. roaming plan, data plan).\\\",\\r\\n        \\\"Make sure the mobile data feature on the device is turned on.\\\",\\r\\n        \\\"Check to make sure Flow supports the action being requested.\\\",\\r\\n        \\\"If the issue persists, turn on airplane mode for 15 seconds, then turn it back off.\\\",\\r\\n        \\\"Perform a device restart.\\\",\\r\\n        \\\"Remove SIM card from the device, wipe it with a dry cloth or pencil eraser, then reinsert and try again.\\\",\\r\\n        \\\"Check to ensure you have Flow SIM card.\\\"\\r\\n    ],\\r\\n    \\\"Unable to Send and/or Receive SMS\\\": [\\r\\n        \\\"Verify that you are subscribed to the service you are trying to use.\\\",\\r\\n        \\\"Make sure the mobile data feature on the device is turned on.\\\",\\r\\n        \\\"Check to make sure Flow supports the action being requested.\\\",\\r\\n        \\\"If the issue persists, turn on airplane mode for 15 seconds, then turn it back off.\\\",\\r\\n        \\\"Perform a device restart.\\\",\\r\\n        \\\"Remove SIM card from the device, wipe it with a dry cloth or pencil eraser, then reinsert and try again.\\\",\\r\\n        \\\"Check to ensure you have Flow SIM card.\\\"\\r\\n    ],\\r\\n    \\\"Credit Not Showing Up\\\": [\\r\\n\\r\\n    ],\\r\\n    \\\"Unable to Receive Calls - Mobile\\\": [\\r\\n\\r\\n    ],\\r\\n    \\\"Activating Roaming\\\": [\\r\\n\\r\\n    ],\\r\\n    \\\"Mobile Data Not Working\\\": [\\r\\n\\r\\n    ],\\r\\n    \\\"General Mobile Tips\\\": [\\r\\n\\r\\n    ]\\r\\n}\""
                        });
                });

            modelBuilder.Entity("PortfolioNoIdentityAPI.Models.TroubleshootingCustomerIssue", b =>
                {
                    b.HasOne("PortfolioNoIdentityAPI.Models.TroubleshootingService", "TroubleshootingServices")
                        .WithMany("TroubleshootingCustomerIssues")
                        .HasForeignKey("TroubleshootingServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TroubleshootingServices");
                });

            modelBuilder.Entity("PortfolioNoIdentityAPI.Models.TroubleshootingServiceType", b =>
                {
                    b.HasOne("PortfolioNoIdentityAPI.Models.TroubleshootingService", "TroubleshootingServices")
                        .WithOne("TroubleshootingServiceTypes")
                        .HasForeignKey("PortfolioNoIdentityAPI.Models.TroubleshootingServiceType", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TroubleshootingServices");
                });

            modelBuilder.Entity("PortfolioNoIdentityAPI.Models.TroubleshootingService", b =>
                {
                    b.Navigation("TroubleshootingCustomerIssues");

                    b.Navigation("TroubleshootingServiceTypes")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}