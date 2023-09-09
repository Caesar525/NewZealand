-- 显示本地批量限制设置
show variables like 'local_infile';

-- 打开客户端和远程批量限制避免出现 To use MySqlBulkLoader.Local=true, set AllowLoadLocalInfile=true in the connection string. See https://fl.vu/mysql-load-data”
-- 测试无效
-- set global set local_infile=on;
-- 避免出现You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near 'set local_infile=on'
set global local_infile=1;
