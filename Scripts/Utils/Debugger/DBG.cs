namespace Assets.Scripts.Utils.Debugger {

    public class DBG {

        // 0 - errors
        // 1 - warnings
        // 2 - logs
        protected const int level = 2;

        public static void Log (object obj) {
            Log(obj, DBG_Type.General);
        }

        public static void Warning (object obj) {
            Warning(obj, DBG_Type.General);
        }

        public static void Error (object obj) {
            Error(obj, DBG_Type.General);
        }

        public static void Log (object obj, DBG_Type dbg_type) {
            if (level >= 2) {
                UnityEngine.Debug.Log(AppendString(MSG_Type.Log, dbg_type, obj));
            }
        }

        public static void Warning (object obj, DBG_Type dbg_type) {
            if (level >= 1) {
                UnityEngine.Debug.Log(AppendString(MSG_Type.Warning, dbg_type, obj));
            }
        }

        public static void Error (object obj, DBG_Type dbg_type) {
            if (level >= 0) {
                UnityEngine.Debug.Log(AppendString(MSG_Type.Error, dbg_type, obj));
            }
        }

        protected static string AppendString (MSG_Type msg_type, DBG_Type dbg_type, object obj) {
            return @"[" + msg_type.ToString() +
                "][" + dbg_type.ToString() +
                "]: " + obj.ToString() + "\n";
        }
    }
}