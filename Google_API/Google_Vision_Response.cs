using System;
using System.Collections.Generic;
using System.Text;

namespace Google_API
{
    public class Google_Vision_Response
    {
        public Respons[] responses { get; set; }
    }

    public class Respons
    {
        public Textannotation[] textAnnotations { get; set; }
        public Fulltextannotation fullTextAnnotation { get; set; }
    }

    public class Fulltextannotation
    {
        public Page[] pages { get; set; }
        public string text { get; set; }
    }

    public class Page
    {
        public Property1 property { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Block[] blocks { get; set; }
    }

    public class Property1
    {
        public Detectedlanguage[] detectedLanguages { get; set; }
    }

    public class Detectedlanguage
    {
        public string languageCode { get; set; }
    }

    public class Block
    {
        public Property2 property { get; set; }
        public Boundingbox boundingBox { get; set; }
        public Paragraph[] paragraphs { get; set; }
        public string blockType { get; set; }
    }

    public class Property2
    {
        public Detectedlanguage1[] detectedLanguages { get; set; }
    }

    public class Detectedlanguage1
    {
        public string languageCode { get; set; }
    }

    public class Boundingbox
    {
        public Vertex[] vertices { get; set; }
    }

    public class Vertex
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Paragraph
    {
        public Property3 property { get; set; }
        public Boundingbox1 boundingBox { get; set; }
        public Word[] words { get; set; }
    }

    public class Property3
    {
        public Detectedlanguage2[] detectedLanguages { get; set; }
    }

    public class Detectedlanguage2
    {
        public string languageCode { get; set; }
    }

    public class Boundingbox1
    {
        public Vertex1[] vertices { get; set; }
    }

    public class Vertex1
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Word
    {
        public Property4 property { get; set; }
        public Boundingbox2 boundingBox { get; set; }
        public Symbol[] symbols { get; set; }
    }

    public class Property4
    {
        public Detectedlanguage3[] detectedLanguages { get; set; }
    }

    public class Detectedlanguage3
    {
        public string languageCode { get; set; }
    }

    public class Boundingbox2
    {
        public Vertex2[] vertices { get; set; }
    }

    public class Vertex2
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Symbol
    {
        public Property5 property { get; set; }
        public Boundingbox3 boundingBox { get; set; }
        public string text { get; set; }
    }

    public class Property5
    {
        public Detectedlanguage4[] detectedLanguages { get; set; }
        public Detectedbreak detectedBreak { get; set; }
    }

    public class Detectedbreak
    {
        public string type { get; set; }
    }

    public class Detectedlanguage4
    {
        public string languageCode { get; set; }
    }

    public class Boundingbox3
    {
        public Vertex3[] vertices { get; set; }
    }

    public class Vertex3
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Textannotation
    {
        public string locale { get; set; }
        public string description { get; set; }
        public Boundingpoly boundingPoly { get; set; }
    }

    public class Boundingpoly
    {
        public Vertex4[] vertices { get; set; }
    }

    public class Vertex4
    {
        public int x { get; set; }
        public int y { get; set; }
    }

}
