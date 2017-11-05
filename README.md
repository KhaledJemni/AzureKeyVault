
# AzureKeyVault
How to use Azure Key Vault in and ASP.NET Project

-	Creating Key Vault sur Azure, in which you store a symmetric key AES 256.
![1](https://user-images.githubusercontent.com/2820473/32329752-3521e76c-bfde-11e7-8a9f-ec581afe8e3c.png) 

![2](https://user-images.githubusercontent.com/2820473/32329862-90c4e4ac-bfde-11e7-99a6-a79c811e06e6.png)


-	Creating a  self-signed certificate with powershell (this one was created with a wild card *cloudapp.net) , with public and private key RSA 2048.



![3](https://user-images.githubusercontent.com/2820473/32329880-9cd1e70e-bfde-11e7-8f12-01fe335e8ff7.png)


 

-	Creating the web app on Azure

![4](https://user-images.githubusercontent.com/2820473/32329892-a84c70a4-bfde-11e7-8df3-78f31896fdcc.png)


-	Get the APP ID from the portal ( I did it from the old one but you can do it form the new one I just did know how at that time ) 

 ![5](https://user-images.githubusercontent.com/2820473/32329910-b34cf8a2-bfde-11e7-8f2e-228681661adf.png)


 
-	Ensuite j’ai créé un projet ASP.NET MVC sur Visual Studio pour développer les API, la première chose à effectuer c’est d’ajouter les Keys sur Web.Config récupéré du KeyVault sur le portail.

![6](https://user-images.githubusercontent.com/2820473/32329934-be7d7210-bfde-11e7-82d4-a1c36cdee161.png)


-	Give permissions to key


![7](https://user-images.githubusercontent.com/2820473/32329948-ca6b2a18-bfde-11e7-86c2-67bbf988ae7b.png)

 

-	adding C# classes Aes256Encryption, Rsa2048Encryption for encryption and decryption. 

-	You will find 4 methods to:

Symetric Encryption : 


![8](https://user-images.githubusercontent.com/2820473/32329989-ec06a7c4-bfde-11e7-8eca-be0768df9760.png)


Symetric Decryption

![9](https://user-images.githubusercontent.com/2820473/32330007-04ab2b2e-bfdf-11e7-8aa3-31e4dfb08e48.png)

Asymetric Encyprtion:


![10](https://user-images.githubusercontent.com/2820473/32330020-129e1ade-bfdf-11e7-8988-62f93afe48e0.png)


Asymetric Decryption:

![11](https://user-images.githubusercontent.com/2820473/32330035-2244d0b8-bfdf-11e7-95a8-4dfb940572a8.png)
