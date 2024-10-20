import System.IO;

function outputChildren(path, header){
    try {
        var caption = Path.GetFileName(path);
        if( caption.Length == 0 ){
            caption = path;
        }
        var cs = Directory.GetDirectories(path);
        var mark = cs.Length>0? "+ ":"- ";
        print( header+mark+caption );

        for( var i=0; i<cs.Length; i++ ){
            outputChildren(cs[i], header+"  ");
        }
    } catch (e){
        print(e);
    }
}
var args = System.Environment.GetCommandLineArgs();
if( args.Length < 2 ){
    print(args.Length);
} else {
    outputChildren(args[1],"");
}