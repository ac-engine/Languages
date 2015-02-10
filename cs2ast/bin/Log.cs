﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ace
{
	/// <summary>
	/// テキスト形式でログを記録し、HTMLファイルに保存する機能を提供するクラス。
	/// </summary>
	public class Log
	{
		/// <summary>
		/// ログの出力レベルを表す列挙体。レベルがLogクラスに設定されたものより高いログのみが記録されます。
		/// </summary>
		public enum OutputLevel
		{
			/// <summary>
			/// プログラムを停止しなければならない状況に関するログの出力レベル。
			/// </summary>
			Error = swig.Log.eLogLevel.LOG_ERROR,
			/// <summary>
			/// プログラムが正常に動作できないことに関するログの出力レベル。
			/// </summary>
			Critical = swig.Log.eLogLevel.LOG_CRITICAL,
			/// <summary>
			/// プログラムが正常に動作することが保証できない状況に関するログの出力レベル。
			/// </summary>
			Warning = swig.Log.eLogLevel.LOG_WARNING,
			/// <summary>
			/// プログラムの動作の異常ではなく、単に動作の状況を示すログの出力レベル。
			/// </summary>
			Information = swig.Log.eLogLevel.LOG_INFORMATION,
			/// <summary>
			/// 最低の出力レベル。
			/// </summary>
			All = swig.Log.eLogLevel.LOG_ALL
		}

		/// <summary>
		/// Logクラスをインスタンス化します。
		/// </summary>
		/// <param name="path">ログファイルを出力するファイル パス。</param>
		/// <param name="title">ログファイルのタイトル。</param>
		public Log( string path, string title )
		{
			log = swig.Log_Imp.Create( path, title );
		}

		/// <summary>
		/// Logクラスをインスタンス化します。
		/// </summary>
		/// <param name="log">ネイティブのラッパー</param>
		internal Log(swig.Log log)
		{
			this.log = log;
		}

		/// <summary>
		/// テキストをログファイルに書き込みます。
		/// </summary>
		/// <param name="text">書き込まれるテキスト。</param>
		/// <param name="level">出力レベル。</param>
		public void Write( string text, OutputLevel level = OutputLevel.All )
		{
			log.Write( text, (int)level );
		}

		/// <summary>
		/// テキストをログファイルに書き込み、つづけて改行を書き込みます。
		/// </summary>
		/// <param name="text">書き込まれるテキスト。</param>
		/// <param name="level">出力レベル。</param>
		public void WriteLine( string text, OutputLevel level = OutputLevel.All )
		{
			log.WriteLine( text, (int)level );
		}

		/// <summary>
		/// テキストを強調されるスタイルでログファイルに書き込みます。
		/// </summary>
		/// <param name="text">書き込まれるテキスト。</param>
		/// <param name="level">出力レベル。</param>
		public void WriteStrongly( string text, OutputLevel level = OutputLevel.All )
		{
			log.WriteStrongly( text, (int)level );
		}

		/// <summary>
		/// テキストを強調されるスタイルでログファイルに書き込み、つづけて改行を書き込みます。
		/// </summary>
		/// <param name="text">書き込まれるテキスト。</param>
		/// <param name="level">出力レベル。</param>
		public void WriteLineStrongly( string text, OutputLevel level = OutputLevel.All )
		{
			log.WriteLineStrongly( text, (int)level );
		}

		/// <summary>
		/// テキストを見出しとしてログファイルに書き込みます。
		/// </summary>
		/// <param name="text">書き込まれるテキスト。</param>
		/// <param name="level">出力レベル。</param>
		public void WriteHeading( string text, OutputLevel level = OutputLevel.All )
		{
			log.WriteHeading( text, (int)level );
		}

		/// <summary>
		/// 水平線をログファイルに書き込みます。
		/// </summary>
		/// <param name="level">出力レベル。</param>
		public void WriteHorizontalRule( OutputLevel level = OutputLevel.All )
		{
			log.WriteHorizontalRule( (int)level );
		}

		/// <summary>
		/// テーブルの開始タグをログファイルに書き込みます。
		/// </summary>
		/// <param name="level">出力レベル。</param>
		public void BeginTable( OutputLevel level = OutputLevel.All )
		{
			log.BeginTable( (int)level );
		}

		/// <summary>
		/// テーブルの終了タグをログファイルに書き込みます。
		/// </summary>
		/// <param name="level">出力レベル。</param>
		public void EndTable( OutputLevel level = OutputLevel.All )
		{
			log.EndTable( (int)level );
		}

		/// <summary>
		/// テーブルの新たな行に移動するタグをログファイルに書き込みます。
		/// </summary>
		/// <param name="level"></param>
		public void ChangeRow( OutputLevel level = OutputLevel.All )
		{
			log.ChangeRow( (int)level );
		}

		/// <summary>
		/// テーブルの新たな列に移動するタグをログファイルに書き込みます。
		/// </summary>
		/// <param name="level"></param>
		public void ChangeColumn( OutputLevel level = OutputLevel.All )
		{
			log.ChangeColumn( (int)level );
		}

		/// <summary>
		/// Logクラスが使用可能かどうかを表す値を取得します。
		/// </summary>
		/// <returns></returns>
		public bool IsValid()
		{
			return log.IsValid();
		}

		/// <summary>
		/// Logクラスが出力するログの出力レベルを設定します。
		/// </summary>
		/// <param name="level">設定する出力レベル。この値よりレベルが高く指定されたログのみが記録されるようになります。</param>
		public void SetOutputLevel( OutputLevel level )
		{
			log.SetOutputLevel( (int)level );
		}

		private swig.Log log;
	}
}
