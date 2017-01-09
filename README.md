# NFramework.ActiveMQ.Client
基于C#  Apache.NMS.ActiveMQ的访问客户端（支持集群）

# 其他说明 
在项目使用过程中，如果网络情况不稳定 CreateSession 可能会有异常，代码中做了捕获并设置阀值，进行连接的重建。（Web项目会有问题，需自己找比较好的解决方案。）
