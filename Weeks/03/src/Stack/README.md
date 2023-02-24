# Generic stack

- Stack má k dispozícii základné operácie ako je `Push`, `Pop` a `Peek`
- Hodnoty sú v zásobníku uložené v špeciálnom wrappery `Item<T>`
- Využitie wrapperu `Item<T>` nám umožňuje spolu s hodnotami ukladať aj metadáta (napr. dátum vloženia, id prvku atď.) o vkladaných hodnotách
- `Item<T>` je realizovaný pomocou `record`
- Zásobník využíva na signalizáciu chybných operácií vlastné exceptions
- Zásobník umožňuje čítať prvky aj mimo vrcholu pomocou indexeru