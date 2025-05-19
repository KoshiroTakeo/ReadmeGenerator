//
// PBコンポーネント項目、MA、lil切り替え
//
//
//
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ReplaceAndSaveTextApp
{
    public class MainForm : Form
    {
        private Panel messagePanel, modelPanel ,inputPanel, BoothPanel;
        private Label messageLabel, dateLA, modelLA, BoothLA;
        private TextBox titleTB, creatorTB, flavorTB,  packageTB, pbTB, meshTB, materialTB, YAGOTB, IntroTB, NotesTB, howtoTB,  modelsoftTB, texsoftTB, unityverTB, sdkverTB, lilverTB, maverTB, urlTB;
        private Button addModelButton, replaceButton, saveButton, avaterBT_tgl ,maBT_tgl, lilBT_tgl, addBoothButton, addModelReMoveButton, addBoothReMoveButton;
        private MonthCalendar releseMC;
        private List<TextBox> modelNameTBes = new List<TextBox>(), polygonCountTBes = new List<TextBox>(), otherboothTBes = new List<TextBox>(),  boothLinkTBes = new List<TextBox>();

        private int n_Pheight = 0;
        private int n_TBheight = 0;
        private int n_horizontal = 10;
        private int n_TB_H = 180;
        private int n_LA_H = 10;
        private int n_distanceV = 20;
        private string s_errorcoment = "!NO CONTEXT!";
        private bool b_avaterItem = false;

        // 各パネルの値
        private int n_messagePanel_h = 300;
        private int n_messagePanel_w = 600;
        private int n_modelPanel_h = 150;
        private int n_modelPanel_w = 360;
        private int n_inputPanel_h = 300;
        private int n_inputPanel_w = 600;
        private int n_FlaverTB_h = 40;
        private int n_FlaverTB_w = 360;
        private int n_FlaverTB_hMAXIM = 100;
        private int n_TB_w = 300;
        private int n_button_w = 100;

        private int n_beforeheight = 0;
        private int n_beforepanelheight = 0;

        private string s_ver = "Ver." + "0.2.0"; // 大規模.バグ不具合.軽微なもの



        public MainForm()
        {
            // Readmeのリザルト表示（スクロール可能）
            messagePanel = new Panel
            {
                Location = new System.Drawing.Point(n_horizontal, addPHeight(n_beforepanelheight)),
                Width = n_messagePanel_w,
                Height = n_messagePanel_h,
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle
            };
            n_beforepanelheight = messagePanel.Height;

            // Readmeの参考文を設定
            messageLabel = new Label
            {
                Text = 
            "◆【商品名】◆\n" +
            "制作者：【制作者名】\n" +
            "\n" +
            "【フレーバーテキスト】\n" +
            "\n" +
            "※DL商品の性質上、返品・返金は出来ません。商品説明、利用規約をご確認・ご了承の上でご購入ください。\n" +
            "※発砲の際は、周囲の方にご配慮のうえご使用ください。人に向けての射撃はお控えくださいますようお願いいたします。\n" +
            "\n" +
             "◆アイテム概要 \n" +
            "●内容物 \n" +
            "・【パッケージ名】.Unitypackage \n" +
            "・FBX \n" +
            "・テクスチャ \n" +
            "・Readme.txt（本文） \n" +
            "利用シェーダー \n" +
            "・liltoon \n" +
            "https://lilxyzw.booth.pm/items/3087170 \n" +
            "\n" +
            "必須アセット \n" +
            "・ModularAvater \n" +
            "https://modular-avatar.nadena.dev/ja/docs/intro \n" +
            "\n" +
            "●モデルデータ \n" +
            "\n" +
            "【メッシュ数、マテリアル数、PBコンポーネント数などあれば追加項目】 \n" +
            "\n" +
            "インポート時のフォルダ \n" +
            "Assets ＞ MetaverseCreators_CP ＞ 【屋号：unity上】 ＞ 【アイテム名：unity上】 \n" +
            "\n" +
            "\n" +
            "◆導入手順 \n" +
            "【導入手順を記載】\n" +
            "【導入時注意事項】\n" +
            "\n" +
            "\n" +
            "◆使い方 \n" +
            "【使い方を記載】\n" +
            "\n" +
            "\n" +
            "◆利用規約 \n" +
            "https://drive.google.com/drive/folders/1qRMXoIxM1ZgacBPfwOigQRtXP1vCbNMn?usp=sharing \n" +
            "※元となるアバターの規約を守ったうえでご利用ください。\n" +
            "\n" +
            "\n" +
            "◆制作環境 \n" +
            "モデリング：【モデリングソフトとバージョン】\n" +
            "テクスチャ：【使用ソフト（あればそのバージョン）】  \n" +
            "セットアップ：Unity　【unityバージョン】 \n" +
            "   VRChat SDK - Avatars 【SDKバージョン】 \n" +
            "   liltoon 【liltoonバージョン】 \n" +
            "   Moduler Avatar 【MAバージョン】 \n" +
            "\n" +
            "◆クレジット \n" +
            "制作者：【制作者名】 \n" +
            "URL（制作者個人BOOTH） 【制作者個人BOOTHURL】\n" +
            "\n" +
            "問い合わせサポート \n" +
            "https://discord.gg/bmw3PWE37M \n" +
            "\n" +
            "◆更新履歴 \n" +
            "【リリース日】 - リリース \n" +
            "\n" ,
            AutoSize = true
            };
            messagePanel.Controls.Add(messageLabel);

            // 入力データの情報を格納するPanel（スクロール可能）
            inputPanel = new Panel
            {
                Location = new System.Drawing.Point(n_horizontal, addPHeight(n_beforepanelheight)),
                Width = n_inputPanel_w,
                Height = n_inputPanel_h,
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle // 境界線を追加して見やすく
            };
            n_beforepanelheight = inputPanel.Height;

            // 各TBの設定-------------------------------------------------------------------------
            titleTB = CreateTB("商品名", false);

            creatorTB = CreateTB("制作者名", false);

            flavorTB = CreateTB("フレーバーテキスト", true, n_FlaverTB_hMAXIM);

            avaterBT_tgl = new Button
            {
                Text = b_avaterItem ? "アバター向け注意文を追加" : "アバター向け注意文を取消",
                Location = new System.Drawing.Point(n_LA_H, addTBHeight(n_beforeheight)),
                Width = 150
            };
            n_beforeheight = avaterBT_tgl.Height;
            avaterBT_tgl.Click += Toggle_avaterItem_Click;
            inputPanel.Controls.Add(avaterBT_tgl);

            packageTB = CreateTB("パッケージ名", false);
            packageTB.Text = ".unitypackage";

            maverTB = CreateTB("", false);
            maBT_tgl = CreateToggleBT("ModularAveterのVer入力\n（クリックで使用しない）");
            maBT_tgl.Click += Toggle_maTB_Click;

            lilverTB = CreateTB("", false);
            lilBT_tgl = CreateToggleBT("lilToonのVer入力\n（クリックで使用しない）");
            lilBT_tgl.Click += Toggle_lilTB_Click;

            meshTB = CreateTB("メッシュ数：", false);

            materialTB = CreateTB("マテリアル数：", false);

            pbTB = CreateTB("PBコンポーネント数", false);

            YAGOTB = CreateTB("unity上屋号", false);

            IntroTB = CreateTB("導入方法", true, n_FlaverTB_hMAXIM);

            NotesTB = CreateTB("導入時の注意事項", true);
            NotesTB.Text = "※";

            // モデルデータの情報を格納するPanel（スクロール可能）
            modelPanel = new Panel
            {
                Location = new System.Drawing.Point(n_TB_H, addTBHeight(n_beforeheight)),
                Width = n_modelPanel_w,
                Height = n_modelPanel_h,
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle // 境界線を追加して見やすく
            };
            n_beforeheight = modelPanel.Height;
            inputPanel.Controls.Add(modelPanel);

            modelLA = new Label
            {
                Text = "モデル名 / ポリゴン数",
                Location = new System.Drawing.Point(n_LA_H, n_TBheight), // ラベルの位置
                AutoSize = true // 自動サイズ調整
            };
            inputPanel.Controls.Add(modelLA);

            // モデル項目を追加するボタン
            addModelButton = new Button
            {
                Text = "モデル項目追加",
                Location = new System.Drawing.Point(n_LA_H, n_TBheight + 20),
                AutoSize = true
                
            };
            addModelButton.Click += AddModelButton_Click;
            inputPanel.Controls.Add(addModelButton);

            // モデル項目を削除するボタン
            addModelReMoveButton = new Button
            {
                Text = "モデル項目削除",
                Location = new System.Drawing.Point(n_LA_H, n_TBheight + 40),
                AutoSize = true

            };
            addModelReMoveButton.Click += addModelReMoveButton_Click;
            inputPanel.Controls.Add(addModelReMoveButton);

            howtoTB = CreateTB("使い方", true, n_FlaverTB_hMAXIM);

            modelsoftTB = CreateTB("モデリングソフトとバージョン", false);

            texsoftTB = CreateTB("使用ソフト（あればそのバージョン）", false);

            unityverTB = CreateTB("unityバージョン", false);

            sdkverTB = CreateTB("SDKバージョン", false);

            urlTB = CreateTB("BoothURL", false);

            // urlデータの情報を格納するPanel（スクロール可能）
            BoothPanel = new Panel
            {
                Location = new System.Drawing.Point(n_TB_H, addTBHeight(n_beforeheight)),
                Width = n_modelPanel_w,
                Height = n_modelPanel_h,
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle // 境界線を追加して見やすく
            };
            n_beforeheight = BoothPanel.Height;
            inputPanel.Controls.Add(BoothPanel);

            BoothLA = new Label
            {
                Text = "その他宣伝サイト/URL",
                Location = new System.Drawing.Point(n_LA_H, n_TBheight), // ラベルの位置
                AutoSize = true // 自動サイズ調整
            };
            inputPanel.Controls.Add(BoothLA);

            // url項目を追加するボタン
            addBoothButton = new Button
            {
                Text = "URL項目追加",
                Location = new System.Drawing.Point(n_LA_H, n_TBheight + 20),
                AutoSize = true

            };
            addBoothButton.Click += AddBoothButton_Click;
            inputPanel.Controls.Add(addBoothButton);

            // モデル項目を削除するボタン
            addBoothReMoveButton = new Button
            {
                Text = "URL項目削除",
                Location = new System.Drawing.Point(n_LA_H, n_TBheight + 40),
                AutoSize = true

            };
            addBoothReMoveButton.Click += addBoothReMoveButton_Click;
            inputPanel.Controls.Add(addBoothReMoveButton);

            releseMC = new MonthCalendar
            {
                Location = new System.Drawing.Point(n_TB_H, addTBHeight(n_beforeheight)), // カレンダーの位置を設定
                MaxSelectionCount = 1 // 複数日選択を禁止（1日だけ選択可能）
            };

            dateLA = new Label
            {
                Text = "リリース日",
                Location = new System.Drawing.Point(n_LA_H, n_TBheight + 10), // ラベルの位置
                AutoSize = true // 自動サイズ調整
            };         

            inputPanel.Controls.Add(releseMC);
            inputPanel.Controls.Add(dateLA);
            // ------------------------------------------------------------------------------------


            // 置き換えボタン
            replaceButton = new Button
            {
                Text = "書き換え",
                Location = new System.Drawing.Point(n_horizontal, addPHeight(n_beforepanelheight)),
                Width = n_button_w
            };
            replaceButton.Click += ReplaceButton_Click;

            // 保存ボタン
            saveButton = new Button
            {
                Text = "テキストに出力",
                Location = new System.Drawing.Point(replaceButton.Location.X + replaceButton.Width + 20, replaceButton.Location.Y),
                Width = n_button_w
            };
            saveButton.Click += SaveButton_Click;

            // フォームにコントロールを追加
            Controls.Add(messagePanel);
            Controls.Add(inputPanel);
            Controls.Add(replaceButton);
            Controls.Add(saveButton);

            // フォーム設定
            Text = "Readmeジェネレーター" + s_ver;
            Size = new System.Drawing.Size(700, 800);
        }

        private void AddModelButton_Click(object sender, EventArgs e)
        {
            // 新しいモデル名とポリゴン数のTBを作成
            int count = modelNameTBes.Count;

            TextBox modelNameTB = new TextBox
            {
                Text = "",
                Location = new System.Drawing.Point(10, 10 + count * 40),
                Width = 150
            };

            TextBox polygonCountTB = new TextBox
            {
                Text = "",
                Location = new System.Drawing.Point(170, 10 + count * 40),
                Width = 150
            };

            // リストに追加
            modelNameTBes.Add(modelNameTB);
            polygonCountTBes.Add(polygonCountTB);

            // Panelに追加
            modelPanel.Controls.Add(modelNameTB);
            modelPanel.Controls.Add(polygonCountTB);
        }
        
        private void addModelReMoveButton_Click(object sender, EventArgs e)
        {
            if (modelPanel.Controls.Count <= 0) return;

            int n;

            n = modelNameTBes.Count * 2 - 1;

            modelPanel.Controls.RemoveAt(n);
            modelPanel.Controls.RemoveAt(n - 1);

            // リストから削除
            polygonCountTBes.RemoveAt(modelNameTBes.Count - 1);
            modelNameTBes.RemoveAt(modelNameTBes.Count - 1);
            
        }

        private void AddBoothButton_Click(object sender, EventArgs e)
        {
            // 新しいBoothURLのTBを作成
            int count = otherboothTBes.Count;

            TextBox detailsTB = new TextBox
            {
                Text = "",
                Location = new System.Drawing.Point(10, 10 + count * 40),
                Width = 150
            };

            TextBox urlTB = new TextBox
            {
                Text = "",
                Location = new System.Drawing.Point(170, 10 + count * 40),
                Width = 150
            };

            // リストに追加
            otherboothTBes.Add(detailsTB);
            boothLinkTBes.Add(urlTB);

            // Panelに追加
            BoothPanel.Controls.Add(detailsTB);
            BoothPanel.Controls.Add(urlTB);

        }

        private void addBoothReMoveButton_Click(object sender, EventArgs e)
        {
            if (BoothPanel.Controls.Count <= 0) return;

            int n;

            n = otherboothTBes.Count * 2 - 1;

            BoothPanel.Controls.RemoveAt(n);
            BoothPanel.Controls.RemoveAt(n - 1);

            //Console.WriteLine(BoothPanel.Count);
            // リストから削除
            boothLinkTBes.RemoveAt(otherboothTBes.Count - 1);
            otherboothTBes.RemoveAt(otherboothTBes.Count - 1);

        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            // ユーザー入力を取得
            string title = titleTB.Text;
            string creator = creatorTB.Text;
            string flavorText = flavorTB.Text;
            string avaternotes = "※本商品はアバター向け衣装モデルです。アバター本体のデータは含まれておりません。";
            string package = packageTB.Text;
            string mesh = meshTB.Text;
            string material = materialTB.Text;
            string pb = pbTB.Text;
            string yago = YAGOTB.Text;
            string intro = IntroTB.Text;
            string notes = NotesTB.Text;
            string howto = howtoTB.Text;
            string modelsoft = modelsoftTB.Text;
            string texsoft = texsoftTB.Text;
            string unityver = unityverTB.Text;
            string sdkver = sdkverTB.Text;
            string lilver = lilverTB.Text;
            string maver = maverTB.Text;
            string url = urlTB.Text;
            string date = releseMC.SelectionStart.ToString("yyyy/MM/dd"); 

            // モデルリストを構築
            string modelData = "";
            for (int i = 0; i < modelNameTBes.Count; i++)
            {
                string modelName = modelNameTBes[i].Text;
                string polygonCount = polygonCountTBes[i].Text;

                modelData += $"{(string.IsNullOrEmpty(modelName) ? s_errorcoment : modelName)}\t：{(string.IsNullOrEmpty(polygonCount) ? s_errorcoment : polygonCount)}ポリゴン\n";
            }

            string addboothData = "";
            for (int i = 0; i < otherboothTBes.Count; i++)
            {
                string boothdetails = otherboothTBes[i].Text;
                string boothURL = boothLinkTBes[i].Text;

                addboothData += $"{(string.IsNullOrEmpty(boothURL) ? "" : $"{(string.IsNullOrEmpty(boothdetails) ? "その他URL ": boothdetails + " ") }" + boothURL)} \n" ;
            }

            

            // Labelのテキストを置き換え
            messageLabel.Text = $"◆　{(string.IsNullOrEmpty(title) ? s_errorcoment : title)}　◆\n" +
                                $"制作者：{(string.IsNullOrEmpty(creator) ? s_errorcoment : creator)}\n" +
                                "\n" +
                                $"{(string.IsNullOrEmpty(flavorText) ? s_errorcoment : flavorText)}\n" +
                                "\n" +
                                $"{(b_avaterItem ? avaternotes + "\n" : "")}" +
                                "※DL商品の性質上、返品・返金は出来ません。商品説明、利用規約をご確認・ご了承の上でご購入ください。\n" +
                                "\n" +
                                "\n" +
                                "◆アイテム概要 \n" +
                                "●内容物 \n" +
                                $"{(string.IsNullOrEmpty(package) ? s_errorcoment : package)}" + " \n" +
                                "・FBX \n" +
                                "・テクスチャ \n" +
                                "・Readme.txt（本文） \n" +
                                "利用シェーダー \n" +
                                $"{ (string.IsNullOrEmpty(lilver) || (lilverTB.Visible == false) ? "なし \n" : "・liltoon \n" + "https://lilxyzw.booth.pm/items/3087170 \n" )} " +
                                "必須アセット \n" +
                                $"{ (string.IsNullOrEmpty(maver) || (maverTB.Visible == false) ? "なし \n" : "・ModularAvater \n" + "https://modular-avatar.nadena.dev/ja/docs/intro \n")} " +
                                "\n" +
                                "●モデルデータ \n" +
                                modelData + "\n" +
                                $"{ (string.IsNullOrEmpty(mesh) ? "" : "メッシュ数：" + mesh + " \n")}" +
                                $"{ (string.IsNullOrEmpty(material) ? "" : "マテリアル数：" + material + " \n")}" +
                                $"{ (string.IsNullOrEmpty(pb) ? "" : "PBコンポーネント数：" + pb + " \n")}" +
                                "\n" +
                                "インポート時のフォルダ \n" +
                                "Assets ＞ MetaverseCreators_CP ＞ " + $"{(string.IsNullOrEmpty(yago) ? s_errorcoment : yago)}" + " ＞ "+ $"{(string.IsNullOrEmpty(package) ? s_errorcoment : package)}" + "\n" +
                                "\n" +
                                "\n" +
                                "◆導入手順 \n" +
                                $"{(string.IsNullOrEmpty(intro) ? s_errorcoment : intro)}\n" +
                                $"{(string.IsNullOrEmpty(notes) ? s_errorcoment : notes)}\n" +
                                "\n" +
                                "\n" +
                                "◆使い方 \n" +
                                $"{(string.IsNullOrEmpty(howto) ? s_errorcoment : howto)}\n" +
                                "\n" +
                                "\n" +
                                "◆利用規約 \n" +
                                "https://drive.google.com/drive/folders/1qRMXoIxM1ZgacBPfwOigQRtXP1vCbNMn?usp=sharing \n" +
                                "※元となるアバターの規約を守ったうえでご利用ください。\n" +
                                "\n" +
                                "\n" +
                                "◆制作環境 \n" +
                                "モデリング：" + $"{(string.IsNullOrEmpty(modelsoft) ? s_errorcoment : modelsoft)}" + "\n" +
                                "テクスチャ：" + $"{ (string.IsNullOrEmpty(texsoft) ? s_errorcoment : texsoft)} " + "\n" +
                                "セットアップ：Unity　" + $"{ (string.IsNullOrEmpty(unityver) ? s_errorcoment : unityver)} " + "\n" +
                                "   VRChat SDK - Avatars " + $"{ (string.IsNullOrEmpty(sdkver) ? s_errorcoment : sdkver)} " + "\n" +
                                $"{ (string.IsNullOrEmpty(lilver) || (lilverTB.Visible == false) ? CheckError(lilverTB) : "   liltoon " + lilver + "\n")} " +
                                $"{ (string.IsNullOrEmpty(maver) || (maverTB.Visible == false) ? CheckError(maverTB) : "  Moduler Avatar " + maver + "\n")} " +
                                "\n" +
                                "◆クレジット \n" +
                                "制作者：" + $"制作者：{ (string.IsNullOrEmpty(creator) ? s_errorcoment : creator)}\n" +
                                "URL（制作者個人BOOTH）" + $"{ (string.IsNullOrEmpty(url) ? s_errorcoment : url)}\n" +
                                addboothData +
                                "\n" +
                                "問い合わせサポート \n" +
                                "https://discord.gg/bmw3PWE37M \n" +
                                "\n" +
                                "◆更新履歴 \n" +
                                $"{ (string.IsNullOrEmpty(date) ? s_errorcoment : date)}" + " - リリース \n" +
                                "\n";
        }

        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // exeフォルダ内に保存
            string exeFolder = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(exeFolder, "readme.txt");

            try
            {
                // Labelのテキストを保存
                File.WriteAllText(filePath, messageLabel.Text);
                MessageBox.Show($"テキストが {filePath} に保存されました。", "保存完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー");
            }
        }

        private int addTBHeight(int add)
        {
            n_TBheight += add + n_distanceV;
            //Console.WriteLine(n_height);
            return n_TBheight;
        }

        private int addPHeight(int add)
        {
            n_Pheight += add + n_distanceV;
            Console.WriteLine(n_Pheight);
            return n_Pheight;
        }

        private TextBox CreateTB(string _text, bool _flaver)
        {
            TextBox tb;
            Label label;

            if (_flaver == true)
            {
                tb = new TextBox
                {
                    Text = "",
                    Location = new System.Drawing.Point(n_TB_H, addTBHeight(n_beforeheight)),
                    Width = n_FlaverTB_w,
                    Height = n_FlaverTB_h,
                    Multiline = true,
                    ScrollBars = ScrollBars.Both
                };
                
            }
            else
            {
                tb = new TextBox
                {
                    Text = "",
                    Location = new System.Drawing.Point(n_TB_H, addTBHeight(n_beforeheight)),
                    Width = n_TB_w
                };
                
            }
            n_beforeheight = tb.Height;
            

            label = new Label
            {
                Text = _text,
                Location = new System.Drawing.Point(n_LA_H, n_TBheight + 5),
                AutoSize = true
            };

            if (inputPanel != null)
            {
                inputPanel.Controls.Add(label);
                inputPanel.Controls.Add(tb);
            }
           
            return tb;

        }

        private TextBox CreateTB(string _text, bool _flaver, int _tbh)
        {
            TextBox tb;
            Label label;

            if (_flaver == true)
            {
                tb = new TextBox
                {
                    Text = "",
                    Location = new System.Drawing.Point(n_TB_H, addTBHeight(n_beforeheight)),
                    Width = n_FlaverTB_w,
                    Height = _tbh,
                    Multiline = true,
                    ScrollBars = ScrollBars.Both
                };

            }
            else
            {
                tb = new TextBox
                {
                    Text = "",
                    Location = new System.Drawing.Point(n_TB_H, addTBHeight(n_beforeheight)),
                    Width = n_TB_w
                };

            }
            n_beforeheight = tb.Height;

            label = new Label
            {
                Text = _text,
                Location = new System.Drawing.Point(n_LA_H, n_TBheight + 5),
                AutoSize = true
            };

            if (inputPanel != null)
            {
                inputPanel.Controls.Add(label);
                inputPanel.Controls.Add(tb);
            }

            return tb;

        }

        private Button CreateToggleBT(string _text)
        {
            Button bt;
            
            bt = new Button
            {
                Text = _text,
                Location = new System.Drawing.Point(n_LA_H, n_TBheight),
                Width = 150,
                AutoSize = true
            };

            if (inputPanel != null)
            {
                inputPanel.Controls.Add(bt);
            }

            return bt;
        }

        private void Toggle_avaterItem_Click(object sender, EventArgs e)
        {
            // 表示状態を切り替え
            b_avaterItem = !b_avaterItem;
            avaterBT_tgl.Text = b_avaterItem ? "アバター向け注意文を追加" : "アバター向け注意文を取消";
        }

        private void Toggle_maTB_Click(object sender, EventArgs e)
        {
            // 表示状態を切り替え
            maverTB.Visible = !maverTB.Visible;
            maBT_tgl.Text = maverTB.Visible ? "ModularAveterのVer入力\n（クリックで使用しない）" : "ModularAveterを使用する";
        }

        private void Toggle_lilTB_Click(object sender, EventArgs e)
        {
            // 表示状態を切り替え
            lilverTB.Visible = !lilverTB.Visible;
            lilBT_tgl.Text = lilverTB.Visible ? "lilToonのVer入力\n（クリックで使用しない）" : "lilToonを使用する";
        }

        private string CheckError(TextBox _tb)
        {
            string s;

            s = _tb.Visible ? s_errorcoment : "";

            return s;
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
