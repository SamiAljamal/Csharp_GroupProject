C R E A T E   D A T A B A S E   j o b _ b o a r d ; 
 
 G O 
 
 U S E   [ j o b _ b o a r d ] 
 
 G O 
 
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ a c c o u n t s ]         S c r i p t   D a t e :   7 / 2 6 / 2 0 1 6   1 0 : 0 9 : 2 1   A M   * * * * * * / 
 
 S E T   A N S I _ N U L L S   O N 
 
 G O 
 
 S E T   Q U O T E D _ I D E N T I F I E R   O N 
 
 G O 
 
 S E T   A N S I _ P A D D I N G   O N 
 
 G O 
 
 C R E A T E   T A B L E   [ d b o ] . [ a c c o u n t s ] ( 
 
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L , 
 
 	 [ f i r s t _ n a m e ]   [ v a r c h a r ] ( 3 5 5 )   N U L L , 
 
 	 [ l a s t _ n a m e ]   [ v a r c h a r ] ( 3 5 5 )   N U L L , 
 
 	 [ e m a i l ]   [ v a r c h a r ] ( 2 5 5 )   N U L L , 
 
 	 [ p h o n e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L , 
 
 	 [ e d u c a t i o n ]   [ i n t ]   N U L L , 
 
 	 [ r e s u m e ]   [ v a r c h a r ] ( 5 0 0 0 )   N U L L 
 
 )   O N   [ P R I M A R Y ] 
 
 
 
 G O 
 
 S E T   A N S I _ P A D D I N G   O F F 
 
 G O 
 
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ c a t e g o r i e s ]         S c r i p t   D a t e :   7 / 2 6 / 2 0 1 6   1 0 : 0 9 : 2 1   A M   * * * * * * / 
 
 S E T   A N S I _ N U L L S   O N 
 
 G O 
 
 S E T   Q U O T E D _ I D E N T I F I E R   O N 
 
 G O 
 
 S E T   A N S I _ P A D D I N G   O N 
 
 G O 
 
 C R E A T E   T A B L E   [ d b o ] . [ c a t e g o r i e s ] ( 
 
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L , 
 
 	 [ n a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L 
 
 )   O N   [ P R I M A R Y ] 
 
 
 
 G O 
 
 S E T   A N S I _ P A D D I N G   O F F 
 
 G O 
 
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ c o m p a n i e s ]         S c r i p t   D a t e :   7 / 2 6 / 2 0 1 6   1 0 : 0 9 : 2 1   A M   * * * * * * / 
 
 S E T   A N S I _ N U L L S   O N 
 
 G O 
 
 S E T   Q U O T E D _ I D E N T I F I E R   O N 
 
 G O 
 
 S E T   A N S I _ P A D D I N G   O N 
 
 G O 
 
 C R E A T E   T A B L E   [ d b o ] . [ c o m p a n i e s ] ( 
 
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L , 
 
 	 [ n a m e ]   [ v a r c h a r ] ( 5 0 0 )   N U L L 
 
 )   O N   [ P R I M A R Y ] 
 
 
 
 G O 
 
 S E T   A N S I _ P A D D I N G   O F F 
 
 G O 
 
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ j o b s ]         S c r i p t   D a t e :   7 / 2 6 / 2 0 1 6   1 0 : 0 9 : 2 1   A M   * * * * * * / 
 
 S E T   A N S I _ N U L L S   O N 
 
 G O 
 
 S E T   Q U O T E D _ I D E N T I F I E R   O N 
 
 G O 
 
 S E T   A N S I _ P A D D I N G   O N 
 
 G O 
 
 C R E A T E   T A B L E   [ d b o ] . [ j o b s ] ( 
 
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L , 
 
 	 [ t i t l e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L , 
 
 	 [ d e s c r i p t i o n ]   [ v a r c h a r ] ( 5 0 0 0 )   N U L L , 
 
 	 [ s a l a r y ]   [ i n t ]   N U L L , 
 
 	 [ c o m p a n y _ i d ]   [ i n t ]   N U L L , 
 
 	 [ c a t e g o r y _ i d ]   [ i n t ]   N U L L 
 
 )   O N   [ P R I M A R Y ] 
 
 
 
 G O 
 
 S E T   A N S I _ P A D D I N G   O F F 
 
 G O 
 
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ j o b s _ k e y w o r d s ]         S c r i p t   D a t e :   7 / 2 6 / 2 0 1 6   1 0 : 0 9 : 2 1   A M   * * * * * * / 
 
 S E T   A N S I _ N U L L S   O N 
 
 G O 
 
 S E T   Q U O T E D _ I D E N T I F I E R   O N 
 
 G O 
 
 C R E A T E   T A B L E   [ d b o ] . [ j o b s _ k e y w o r d s ] ( 
 
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L , 
 
 	 [ j o b _ i d ]   [ i n t ]   N U L L , 
 
 	 [ k e y w o r d _ i d ]   [ i n t ]   N U L L , 
 
 	 [ n u m b e r _ o f _ r e p e a t s ]   [ i n t ]   N U L L 
 
 )   O N   [ P R I M A R Y ] 
 
 
 
 G O 
 
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ k e y w o r d s ]         S c r i p t   D a t e :   7 / 2 6 / 2 0 1 6   1 0 : 0 9 : 2 1   A M   * * * * * * / 
 
 S E T   A N S I _ N U L L S   O N 
 
 G O 
 
 S E T   Q U O T E D _ I D E N T I F I E R   O N 
 
 G O 
 
 S E T   A N S I _ P A D D I N G   O N 
 
 G O 
 
 C R E A T E   T A B L E   [ d b o ] . [ k e y w o r d s ] ( 
 
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L , 
 
 	 [ w o r d ]   [ v a r c h a r ] ( 2 5 5 )   N U L L 
 
 )   O N   [ P R I M A R Y ] 
 
 
 
 G O 
 
 S E T   A N S I _ P A D D I N G   O F F 
 
 G O 
 
 
