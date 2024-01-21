-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 21 Sty 2024, 16:56
-- Wersja serwera: 10.4.24-MariaDB
-- Wersja PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `takout_db`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `dishes`
--

CREATE TABLE `dishes` (
  `dish_id` int(4) NOT NULL,
  `dish_name` tinytext NOT NULL,
  `description` mediumtext DEFAULT NULL,
  `price` float(4,2) NOT NULL,
  `restaurant_id` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `dishes`
--

INSERT INTO `dishes` (`dish_id`, `dish_name`, `description`, `price`, `restaurant_id`) VALUES
(1, 'ssssssssss', 'verrry_niceDish', 23.50, 3),
(2, 'some_dish2', 'nice dish2', 21.37, 3),
(5, 'ddd', 'verrry_niceDish', 23.00, 1),
(6, 'ssssssssss', 'verrry_niceDish', 23.00, 1),
(10, 'first_dish', 'This Dish contains some nice ingredients', 24.99, 4);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `dishes_in_orders`
--

CREATE TABLE `dishes_in_orders` (
  `order_id` int(4) DEFAULT NULL,
  `dish_id` int(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `dishes_in_orders`
--

INSERT INTO `dishes_in_orders` (`order_id`, `dish_id`) VALUES
(1, 1),
(15, 1),
(15, 2),
(16, 1),
(16, 2),
(17, 1),
(17, 2),
(18, 1),
(18, 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `orders`
--

CREATE TABLE `orders` (
  `order_id` int(4) NOT NULL,
  `restaurant_id` int(4) DEFAULT NULL,
  `user_id` int(4) DEFAULT NULL,
  `date` datetime NOT NULL DEFAULT current_timestamp(),
  `Longitude` decimal(10,6) DEFAULT NULL,
  `Latitude` decimal(10,6) DEFAULT NULL,
  `order_status` int(11) NOT NULL DEFAULT 0
) ;

--
-- Zrzut danych tabeli `orders`
--

INSERT INTO `orders` (`order_id`, `restaurant_id`, `user_id`, `date`, `Longitude`, `Latitude`, `order_status`) VALUES
(1, 1, 1, '2024-01-04 07:19:00', '12.500000', '12.500000', 1),
(2, 1, 1, '2024-01-04 07:42:20', '13.700000', '12.500000', 0),
(3, 1, 1, '2024-01-04 07:47:59', '13.700000', '12.500000', 0),
(4, 1, 1, '2024-01-04 07:48:38', '13.700000', '12.500000', 0),
(5, 1, 1, '2024-01-04 07:49:37', '13.700000', '12.500000', 0),
(6, 1, 1, '2024-01-04 07:50:23', '13.700000', '12.500000', 0),
(7, 1, 1, '2024-01-04 07:52:04', '13.700000', '12.500000', 0),
(8, 1, 1, '2024-01-04 07:58:10', '13.700000', '12.500000', 0),
(9, 1, 1, '2024-01-04 08:00:23', '13.700000', '12.500000', 0),
(10, 1, 1, '2024-01-04 08:00:38', '13.700000', '12.500000', 0),
(11, 1, 1, '2024-01-04 08:09:13', '13.700000', '12.500000', 0),
(12, 1, 1, '2024-01-04 08:09:34', '13.700000', '12.500000', 0),
(13, 1, 1, '2024-01-04 08:11:44', '13.700000', '12.500000', 0),
(14, 1, 1, '2024-01-04 08:12:00', '13.700000', '12.500000', 0),
(15, 1, 1, '2024-01-04 08:13:08', '13.700000', '12.500000', 0),
(16, 1, 1, '2024-01-04 08:13:41', '13.700000', '12.500000', 0),
(17, 1, 1, '2024-01-04 08:28:08', '13.700000', '12.500000', 0),
(18, 4, 1, '2024-01-04 08:39:34', '13.700000', '12.500000', 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `restaurants`
--

CREATE TABLE `restaurants` (
  `restaurantId` int(4) NOT NULL,
  `restaurnat_name` tinytext NOT NULL,
  `PASSWORD` tinytext NOT NULL,
  `longitude` decimal(10,6) DEFAULT NULL,
  `latitude` decimal(10,6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `restaurants`
--

INSERT INTO `restaurants` (`restaurantId`, `restaurnat_name`, `PASSWORD`, `longitude`, `latitude`) VALUES
(1, 'some_name', 'some_pass', NULL, NULL),
(2, 'password', 'rest_name', NULL, NULL),
(3, 'rest_na111234', 'password', NULL, NULL),
(4, 'McDonalds', '3D-BC-36-5B-7E-92-50-5F-3E-8A-FA-D3-68-76-E6-CE-0C-B7-5E-CA-31-82-2F-AB-A3-74-70-BD-85-4D-44-43-B2-CF-C6-1F-C0-16-F8-92-93-F4-04-C0-2D-1D-0C-06-6E-7F-81-80-24-78-26-00-1E-C3-1D-20-0B-22-07-A5', '123.500000', '123.000000'),
(5, 'Nice Restaurant', 'FD-37-CA-5C-A8-76-3A-E0-77-A5-E9-74-02-12-31-95-91-60-3C-42-A0-8A-60-DC-C9-1D-12-E7-E4-57-B0-24-F6-BD-FD-C1-0C-DC-13-83-E1-60-2F-F2-09-2B-4B-C1-BB-8C-AC-93-06-A9-96-5E-B3-52-43-5F-5D-FE-8B-B0', '12.000000', '12.000000'),
(6, 'King Burger', 'FD-37-CA-5C-A8-76-3A-E0-77-A5-E9-74-02-12-31-95-91-60-3C-42-A0-8A-60-DC-C9-1D-12-E7-E4-57-B0-24-F6-BD-FD-C1-0C-DC-13-83-E1-60-2F-F2-09-2B-4B-C1-BB-8C-AC-93-06-A9-96-5E-B3-52-43-5F-5D-FE-8B-B0', '18.000000', '17.000000');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `user_id` int(4) NOT NULL,
  `username` tinytext NOT NULL,
  `password` tinytext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `users`
--

INSERT INTO `users` (`user_id`, `username`, `password`) VALUES
(1, 'some_user', 'pass_123');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `dishes`
--
ALTER TABLE `dishes`
  ADD PRIMARY KEY (`dish_id`),
  ADD KEY `rest_fk` (`restaurant_id`);

--
-- Indeksy dla tabeli `dishes_in_orders`
--
ALTER TABLE `dishes_in_orders`
  ADD KEY `order_id` (`order_id`),
  ADD KEY `dish_id` (`dish_id`);

--
-- Indeksy dla tabeli `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `restaurant_id` (`restaurant_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indeksy dla tabeli `restaurants`
--
ALTER TABLE `restaurants`
  ADD PRIMARY KEY (`restaurantId`);

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `dishes`
--
ALTER TABLE `dishes`
  MODIFY `dish_id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT dla tabeli `orders`
--
ALTER TABLE `orders`
  MODIFY `order_id` int(4) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT dla tabeli `restaurants`
--
ALTER TABLE `restaurants`
  MODIFY `restaurantId` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT dla tabeli `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `dishes`
--
ALTER TABLE `dishes`
  ADD CONSTRAINT `rest_fk` FOREIGN KEY (`restaurant_id`) REFERENCES `restaurants` (`restaurantId`) ON DELETE CASCADE;

--
-- Ograniczenia dla tabeli `dishes_in_orders`
--
ALTER TABLE `dishes_in_orders`
  ADD CONSTRAINT `dishes_in_orders_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `dishes_in_orders_ibfk_2` FOREIGN KEY (`dish_id`) REFERENCES `dishes` (`dish_id`) ON DELETE CASCADE;

--
-- Ograniczenia dla tabeli `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`restaurant_id`) REFERENCES `restaurants` (`restaurantId`) ON DELETE CASCADE,
  ADD CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
