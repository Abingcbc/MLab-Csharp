CREATE TABLE `User` (
`username` varchar(255) NOT NULL,
`password` varchar(255) NOT NULL,
PRIMARY KEY (`username`) 
);
CREATE TABLE `Dataset` (
`datasetId` int(11) NOT NULL AUTO_INCREMENT,
`username` varchar(255) NULL,
`datasetName` varchar(255) NULL,
`format` varchar(255) NULL,
`size` double NULL,
`createTime` datetime NULL,
PRIMARY KEY (`datasetId`) 
);
CREATE TABLE `MLModel` (
`modelId` int(11) NOT NULL AUTO_INCREMENT,
`username` varchar(255) NULL,
`modelName` varchar(255) NULL,
`description` varchar(255) NULL,
`createTime` datetime NULL,
`status` int(1) NULL,
PRIMARY KEY (`modelId`) 
);
CREATE TABLE `Post` (
`postId` int(11) NOT NULL AUTO_INCREMENT,
`username` varchar(255) NULL,
`title` varchar(255) NULL,
`modelId` int(11) NULL,
`content` varchar(1023) NULL,
`createTime` datetime NULL,
`likeNum` int(11) NULL,
`replyNum` int(11) NULL,
`commentNum` int(11) NULL,
`status` int(1) NULL,
PRIMARY KEY (`postId`) 
);
CREATE TABLE `Likes` (
`likeId` int(11) NOT NULL AUTO_INCREMENT,
`typeId` int(11) NULL,
`type` int(1) NULL,
`username` varchar(255) NULL,
`status` int(1) NULL,
`createTime` datetime NULL,
PRIMARY KEY (`likeId`) 
);
CREATE TABLE `Reply` (
`replyId` int(11) NOT NULL AUTO_INCREMENT,
`username` varchar(255) NULL,
`commentId` int(11) NULL,
`content` varchar(1023) NULL,
`createTime` datetime NULL,
`status` int(1) NULL,
PRIMARY KEY (`replyId`) 
);
CREATE TABLE `Comment` (
`commentId` int(11) NOT NULL AUTO_INCREMENT,
`postId` int(11) NULL,
`username` varchar(255) NULL,
`content` varchar(1023) NULL,
`createTime` datetime NULL,
`status` int(1) NULL,
PRIMARY KEY (`commentId`) 
);
CREATE TABLE `Container` (
`containerId` int(11) NOT NULL,
`username` varchar(255) NULL,
`createTime` datetime NULL,
`invalidTime` datetime NULL,
PRIMARY KEY (`containerId`) 
);

ALTER TABLE `Dataset` ADD CONSTRAINT `fk_DATASET` FOREIGN KEY (`username`) REFERENCES `User` (`username`);
ALTER TABLE `MLModel` ADD CONSTRAINT `fk_MODEL` FOREIGN KEY (`username`) REFERENCES `User` (`username`);
ALTER TABLE `Post` ADD CONSTRAINT `fk_POST` FOREIGN KEY (`username`) REFERENCES `User` (`username`);
ALTER TABLE `Likes` ADD CONSTRAINT `fk_LIKE` FOREIGN KEY (`username`) REFERENCES `User` (`username`);
ALTER TABLE `Reply` ADD CONSTRAINT `fk_REPLY` FOREIGN KEY (`username`) REFERENCES `User` (`username`);
ALTER TABLE `Reply` ADD CONSTRAINT `fk_REPLY_1` FOREIGN KEY (`commentId`) REFERENCES `Comment` (`commentId`);
ALTER TABLE `Comment` ADD CONSTRAINT `fk_COMMENT` FOREIGN KEY (`postId`) REFERENCES `Post` (`postId`);
ALTER TABLE `Comment` ADD CONSTRAINT `fk_COMMENT_1` FOREIGN KEY (`username`) REFERENCES `User` (`username`);
ALTER TABLE `Post` ADD CONSTRAINT `fk_POST_1` FOREIGN KEY (`modelId`) REFERENCES `MLModel` (`modelId`);
ALTER TABLE `Container` ADD CONSTRAINT `fk_Container` FOREIGN KEY (`username`) REFERENCES `User` (`username`);

