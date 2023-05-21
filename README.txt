Bonjour.

Pour lancer l'application il suffit de prendre le dossier publish et le mettre au niveau de inetpub/wwwroot/publish.
Puis -> clic droit sur le dossier qui apparait dans IIS et "Convertir en application".
Il est necessaire pour le projet d'avoir la database correspondant a la connection string dans le web.config.
Dans notre cas le nom de la DB est "VideoGames".
Il sera aussi probablement necessaire de mettre les droits necessaires a l'utilisateur IIS pour qu'il puisse acceder a la database.
Nous avons laisse la variable d'environnement ASPNETCORE_CONFIG="Development" dans le csproj afin d'avoir des logs plus explicites
au moment d'essayer d'acceder a la database.

L'admin par défaut est:
Username: Admin
Password: Test123__

Une fois connecté il est possible pour un administrateur de créer des studios, catégories de jeux, des jeux ainsi que des vendeurs.
Une fois le venduer créé il est possible de se connecter à son compte via le mot de passe que l'administrateur a indiqué.
Attention toutefois il faut mettre un mot de passe robuste sans quoi l'utilisateur n'est pas créé (nous n'avons pas réussi à le
logger sur l'interface)
Une fois connecté au compte de l'utilisateur il peut donc se rajouter du stock, voir son stock et créer des factures.

Il est évidemment possible de créer plusieurs vendeurs simultanément qui auront leur propre stock individuel.
L'administrateur fait office de Stock central, c'est à dire que les utilisateurs vont tout chercher chez lui lorsqu'ils font un restock.
C'est pourquoi lorsaue l'administrateur créé un jeu il doit indiquer son stock.