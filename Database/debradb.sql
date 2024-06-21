-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 21, 2024 at 04:18 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `debradb`
--

-- --------------------------------------------------------

--
-- Table structure for table `events`
--

CREATE TABLE `events` (
  `eventid` varchar(50) NOT NULL,
  `event_name` varchar(255) NOT NULL,
  `ticket_price` int(10) NOT NULL,
  `email` varchar(255) NOT NULL,
  `date` varchar(100) NOT NULL,
  `time` varchar(100) NOT NULL,
  `location` varchar(255) NOT NULL,
  `description` varchar(512) NOT NULL,
  `imageUrl` varchar(255) NOT NULL,
  `soldTickets` int(20) NOT NULL,
  `remainingTickets` int(20) NOT NULL,
  `commissionRate` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `events`
--

INSERT INTO `events` (`eventid`, `event_name`, `ticket_price`, `email`, `date`, `time`, `location`, `description`, `imageUrl`, `soldTickets`, `remainingTickets`, `commissionRate`) VALUES
('2406172016', ' Fashion Week Extravaganza', 100, 'test@gmail.com', '2024-06-19', '10:00 AM', 'New York, NY, USA', 'A week-long event showcasing the latest trends and collections from top fashion designers.', 'Uploads/2406172016.jpg', 1130, 1870, 20),
('2406190846', ' Tech Innovators Conference 2024', 1000, 'abcd@gmail.com', '2024-05-25', '08:00 AM', 'San Francisco, CA, USA', 'A gathering of technology leaders and innovators to discuss the latest trends and future directions in tech.', 'Uploads/2406190846.jpg', 2190, 1810, 5),
('2406190847', 'Annual Health and Wellness Expo', 500, 'abcd@gmail.com', '2024-08-01', '08:00 AM', 'Chicago, IL, USA', 'A comprehensive event showcasing the latest in health, fitness, and wellness products and services.', 'Uploads/2406190847.jpg', 300, 700, 10),
('2406190849', 'Culinary Arts Showcase', 1000, 'abcd@gmail.com', '2024-12-12', '09:00 AM', 'Paris, France', 'A gastronomic event featuring renowned chefs and culinary artists presenting their latest creations.', 'Uploads/2406190849.jpg', 2000, 2000, 12);

-- --------------------------------------------------------

--
-- Table structure for table `partners`
--

CREATE TABLE `partners` (
  `id` int(20) NOT NULL,
  `company_name` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `contact_no` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `partners`
--

INSERT INTO `partners` (`id`, `company_name`, `email`, `password`, `address`, `contact_no`) VALUES
(10, 'ABCD', 'abcd@gmail.com', '1234', 'aa aaa', '1245369875'),
(11, 'TEST', 'test@gmail.com', '1234', 'aaa aaa', '7845965432');

-- --------------------------------------------------------

--
-- Table structure for table `sales`
--

CREATE TABLE `sales` (
  `salesid` varchar(40) NOT NULL,
  `eventid` varchar(100) NOT NULL,
  `user_email` varchar(255) NOT NULL,
  `tickets_purchased` int(10) NOT NULL,
  `total_price` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sales`
--

INSERT INTO `sales` (`salesid`, `eventid`, `user_email`, `tickets_purchased`, `total_price`) VALUES
('001', '2406190846', 'john@gmail.com', 100, 100000),
('S20240620155551', '2406172016', 'john@gmail.com', 10, 1000);

-- --------------------------------------------------------

--
-- Table structure for table `useraccounts`
--

CREATE TABLE `useraccounts` (
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `usertype` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `useraccounts`
--

INSERT INTO `useraccounts` (`email`, `password`, `usertype`) VALUES
('abcd@gmail.com', '1234', 'partner'),
('admin@gmail.com', '1234', 'admin'),
('john@gmail.com', '1234', 'user'),
('test@gmail.com', '1234', 'partner');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `contact_no` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `email`, `password`, `address`, `contact_no`) VALUES
(5, 'John Smith', 'john@gmail.com', '1234', 'No 24, Main street', '01265478952');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `events`
--
ALTER TABLE `events`
  ADD PRIMARY KEY (`eventid`);

--
-- Indexes for table `partners`
--
ALTER TABLE `partners`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sales`
--
ALTER TABLE `sales`
  ADD PRIMARY KEY (`salesid`,`eventid`);

--
-- Indexes for table `useraccounts`
--
ALTER TABLE `useraccounts`
  ADD PRIMARY KEY (`email`,`password`,`usertype`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `partners`
--
ALTER TABLE `partners`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
