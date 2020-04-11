ALTER TABLE `DATASET` DROP FOREIGN KEY `fk_DATASET`;
ALTER TABLE `MLMODEL` DROP FOREIGN KEY `fk_MODEL`;
ALTER TABLE `HISTORY` DROP FOREIGN KEY `fk_HISTORY`;
ALTER TABLE `HISTORY` DROP FOREIGN KEY `fk_HISTORY_2`;
ALTER TABLE `POST` DROP FOREIGN KEY `fk_POST`;
ALTER TABLE `LIKES` DROP FOREIGN KEY `fk_LIKE`;
ALTER TABLE `REPLY` DROP FOREIGN KEY `fk_REPLY`;
ALTER TABLE `REPLY` DROP FOREIGN KEY `fk_REPLY_1`;
ALTER TABLE `COMMENT` DROP FOREIGN KEY `fk_COMMENT`;
ALTER TABLE `COMMENT` DROP FOREIGN KEY `fk_COMMENT_1`;
ALTER TABLE `POST` DROP FOREIGN KEY `fk_POST_1`;

DROP TABLE `USER`;
DROP TABLE `DATASET`;
DROP TABLE `MLMODEL`;
DROP TABLE `HISTORY`;
DROP TABLE `POST`;
DROP TABLE `LIKES`;
DROP TABLE `REPLY`;
DROP TABLE `COMMENT`;

CREATE TABLE `USER` (
`username` varchar(255) NOT NULL,
`password` varchar(255) NOT NULL,
PRIMARY KEY (`username`) 
);
CREATE TABLE `DATASET` (
`dataset_id` int(11) NOT NULL AUTO_INCREMENT,
`username` varchar(255) NULL,
`dataset_name` varchar(255) NULL,
`format` varchar(255) NULL,
`size` double NULL,
`create_time` datetime NULL,
PRIMARY KEY (`dataset_id`) 
);
CREATE TABLE `MLMODEL` (
`model_id` int(11) NOT NULL AUTO_INCREMENT,
`username` varchar(255) NULL,
`model_name` varchar(255) NULL,
`detail` blob NULL,
`description` varchar(255) NULL,
`create_time` datetime NULL,
PRIMARY KEY (`model_id`) 
);
CREATE TABLE `HISTORY` (
`train_id` int(11) NOT NULL AUTO_INCREMENT,
`username` varchar(255) NULL,
`model_id` int(11) NULL,
`start_time` datetime NULL,
`end_time` datetime NULL,
PRIMARY KEY (`train_id`) 
);
CREATE TABLE `POST` (
`post_id` int(11) NOT NULL AUTO_INCREMENT,
`username` varchar(255) NULL,
`title` varchar(255) NULL,
`model_id` int(11) NULL,
`content` varchar(1023) NULL,
`create_time` datetime NULL,
`like_num` int(11) NULL,
`reply_num` int(11) NULL,
`comment_num` int(11) NULL,
`status` int(1) NULL,
PRIMARY KEY (`post_id`) 
);
CREATE TABLE `LIKES` (
`like_id` int(11) NOT NULL AUTO_INCREMENT,
`type_id` int(11) NULL,
`type` int(1) NULL,
`username` varchar(255) NULL,
`status` int(1) NULL,
`create_time` datetime NULL,
PRIMARY KEY (`like_id`) 
);
CREATE TABLE `REPLY` (
`reply_id` int(11) NOT NULL AUTO_INCREMENT,
`username` varchar(255) NULL,
`comment_id` int(11) NULL,
`content` varchar(1023) NULL,
`create_time` datetime NULL,
`status` int(1) NULL,
PRIMARY KEY (`reply_id`) 
);
CREATE TABLE `COMMENT` (
`comment_id` int(11) NOT NULL AUTO_INCREMENT,
`post_id` int(11) NULL,
`username` varchar(255) NULL,
`content` varchar(1023) NULL,
`create_time` datetime NULL,
`status` int(1) NULL,
PRIMARY KEY (`comment_id`) 
);

ALTER TABLE `DATASET` ADD CONSTRAINT `fk_DATASET` FOREIGN KEY (`username`) REFERENCES `USER` (`username`);
ALTER TABLE `MLMODEL` ADD CONSTRAINT `fk_MODEL` FOREIGN KEY (`username`) REFERENCES `USER` (`username`);
ALTER TABLE `HISTORY` ADD CONSTRAINT `fk_HISTORY` FOREIGN KEY (`username`) REFERENCES `USER` (`username`);
ALTER TABLE `HISTORY` ADD CONSTRAINT `fk_HISTORY_2` FOREIGN KEY (`model_id`) REFERENCES `MLMODEL` (`model_id`);
ALTER TABLE `POST` ADD CONSTRAINT `fk_POST` FOREIGN KEY (`username`) REFERENCES `USER` (`username`);
ALTER TABLE `LIKES` ADD CONSTRAINT `fk_LIKE` FOREIGN KEY (`username`) REFERENCES `USER` (`username`);
ALTER TABLE `REPLY` ADD CONSTRAINT `fk_REPLY` FOREIGN KEY (`username`) REFERENCES `USER` (`username`);
ALTER TABLE `REPLY` ADD CONSTRAINT `fk_REPLY_1` FOREIGN KEY (`comment_id`) REFERENCES `COMMENT` (`comment_id`);
ALTER TABLE `COMMENT` ADD CONSTRAINT `fk_COMMENT` FOREIGN KEY (`post_id`) REFERENCES `POST` (`post_id`);
ALTER TABLE `COMMENT` ADD CONSTRAINT `fk_COMMENT_1` FOREIGN KEY (`username`) REFERENCES `USER` (`username`);
ALTER TABLE `POST` ADD CONSTRAINT `fk_POST_1` FOREIGN KEY (`model_id`) REFERENCES `MLMODEL` (`model_id`);

