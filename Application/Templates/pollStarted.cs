﻿
namespace Application.Templates
{
    public class PollStartedTemplate
    {
        public const string Template =
        @"
        <!DOCTYPE html>

        <html lang='en' xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:v='urn:schemas-microsoft-com:vml'>
        <head>
        <title></title>
        <meta content='text/html; charset=utf-8' http-equiv='Content-Type'/>
        <meta content='width=device-width, initial-scale=1.0' name='viewport'/>
        <!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]-->
        <!--[if !mso]><!-->
        <link href='https://fonts.googleapis.com/css?family=Roboto' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Abril+Fatface' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Merriweather' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Montserrat' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Nunito' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Bitter' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Permanent+Marker' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Roboto+Slab' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Cabin' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Oxygen' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Lato' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Ubuntu' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Droid+Serif' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Playfair+Display' rel='stylesheet' type='text/css'/>
        <!--<![endif]-->
        <style>
		        * {
			        box-sizing: border-box;
		        }

		        body {
			        margin: 0;
			        padding: 0;
		        }

		        a[x-apple-data-detectors] {
			        color: inherit !important;
			        text-decoration: inherit !important;
		        }

		        #MessageViewBody a {
			        color: inherit;
			        text-decoration: none;
		        }

		        p {
			        line-height: inherit
		        }

		        @media (max-width:700px) {
			        .icons-inner {
				        text-align: center;
			        }

			        .icons-inner td {
				        margin: 0 auto;
			        }

			        .row-content {
				        width: 100% !important;
			        }

			        .column .border {
				        display: none;
			        }

			        table {
				        table-layout: fixed !important;
			        }

			        .stack .column {
				        width: 100%;
				        display: block;
			        }
		        }
	        </style>
        </head>
        <body style='background-color: #fafafa; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;'>
        <table border='0' cellpadding='0' cellspacing='0' class='nl-container' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #fafafa;' width='100%'>
        <tbody>
        <tr>
        <td>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-1' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tbody>
        <tr>
        <td>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'>
        <tbody>
        <tr>
        <td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
        <table border='0' cellpadding='0' cellspacing='0' class='icons_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tr>
        <td style='vertical-align: middle; color: #000000; font-family: inherit; font-size: 14px; padding-bottom: 5px; padding-left: 30px; padding-right: 30px; text-align: center; padding-top: 30px;'>
        <table align='center' cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;'>
        <tr>
        <td style='vertical-align: middle; text-align: center; padding-top: 5px; padding-bottom: 5px; padding-left: 5px; padding-right: 5px;'><img align='center' alt='Voting Service' class='icon' height='64' src='https://upload.wikimedia.org/wikipedia/commons/c/c6/Sign-check-icon.png' style='display: block; height: auto; margin: 0 auto; border: 0;' width='64'/></td>
        </tr>
        </table>
        </td>
        </tr>
        </table>
        <table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
        <tr>
        <td>
        <div style='font-family: sans-serif'>
        <div class='txtTinyMce-wrapper' style='font-size: 12px; mso-line-height-alt: 18px; color: #1d1d1b; line-height: 1.5; font-family: Lato, Tahoma, Verdana, Segoe, sans-serif;'>
        <p style='margin: 0; font-size: 14px; text-align: center;'><em><span style='font-size:12px;'>Voting Service</span></em></p>
        </div>
        </div>
        </td>
        </tr>
        </table>
        </td>
        </tr>
        </tbody>
        </table>
        </td>
        </tr>
        </tbody>
        </table>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-2' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tbody>
        <tr>
        <td>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'>
        <tbody>
        <tr>
        <td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 0px; padding-bottom: 0px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
        <div class='spacer_block' style='height:20px;line-height:20px;font-size:1px;'> </div>
        </td>
        </tr>
        </tbody>
        </table>
        </td>
        </tr>
        </tbody>
        </table>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-3' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tbody>
        <tr>
        <td>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f6f1ed; color: #000000; width: 680px;' width='680'>
        <tbody>
        <tr>
        <td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
        <table border='0' cellpadding='0' cellspacing='0' class='heading_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tr>
        <td style='padding-bottom:30px;padding-left:20px;padding-right:20px;text-align:center;width:100%;padding-top:40px;'>
                                                                        <h1 style='margin: 0; color: #f2663f; direction: ltr; font-family: 'Playfair Display', Georgia, serif; font-size: 39px; font-weight: 400; letter-spacing: normal; line-height: 120%; text-align: center; margin-top: 0; margin-bottom: 0;'><span class='tinyMce-placeholder'>The poll has started</span></h1>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table border='0' cellpadding='0' cellspacing='0' class='button_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
                                                                <tr>
                                                                    <td style='padding-left:5px;text-align:center;padding-bottom:50px;'>
                                                                        <div align='center'>
                                                                            <!--[if mso]><v:roundrect xmlns:v='urn:schemas-microsoft-com:vml' xmlns:w='urn:schemas-microsoft-com:office:word' href='http://www.example.com' style='height:56px;width:184px;v-text-anchor:middle;' arcsize='0%' stroke='false' fillcolor='#f2663f'><w:anchorlock/><v:textbox inset='0px,0px,0px,0px'><center style='color:#ffffff; font-family:Tahoma, Verdana, sans-serif; font-size:18px'><![endif]--><a href='{{PollLink}}' style='text-decoration:none;display:inline-block;color:#ffffff;background-color:#f2663f;border-radius:0px;width:auto;border-top:0px solid #FFFFFF;font-weight:400;border-right:0px solid #FFFFFF;border-bottom:0px solid #FFFFFF;border-left:0px solid #FFFFFF;padding-top:10px;padding-bottom:10px;font-family:Lato, Tahoma, Verdana, Segoe, sans-serif;text-align:center;mso-border-alt:none;word-break:keep-all;' target='_blank'><span style='padding-left:40px;padding-right:40px;font-size:18px;display:inline-block;letter-spacing:1px;'><span style='font-size: 16px; line-height: 2; word-break: break-word; mso-line-height-alt: 32px;'><span data-mce-style='font-size: 18px; line-height: 36px;' style='font-size: 18px; line-height: 36px;'>VOTE NOW</span></span></span></a>
                                                                            <!--[if mso]></center></v:textbox></v:roundrect><![endif]-->
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-4' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
                                <tbody>
                                    <tr>
                                        <td>
                                            <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
                                                <tbody>
                                                    <tr class='reverse'>
                                                        <td class='column column-1 first' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 50px; padding-right: 50px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='50%'>
                                                            <table border='0' cellpadding='0' cellspacing='0' class='heading_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
                                                                <tr>
                                                                    <td style='padding-bottom:15px;text-align:center;width:100%;padding-top:60px;'>
                                                                        <h2 style='margin: 0; color: #000000; direction: ltr; font-family: 'Playfair Display', Georgia, serif; font-size: 22px; font-weight: 400; letter-spacing: normal; line-height: 120%; text-align: left; margin-top: 0; margin-bottom: 0;'><span class='tinyMce-placeholder'>{{PollName}}</span></h2>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table border='0' cellpadding='0' cellspacing='0' class='divider_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
                                                                <tr>
                                                                    <td style='padding-bottom:10px;padding-right:10px;padding-top:10px;'>
                                                                        <table border='0' cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='30%'>
                                                                            <tr>
                                                                                <td class='divider_inner' style='font-size: 1px; line-height: 1px; border-top: 2px solid #FFD3C5;'><span> </span></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
                                                                <tr>
                                                                    <td style='padding-bottom:30px;'>
                                                                        <div style='font-family: sans-serif'>
                                                                            <div class='txtTinyMce-wrapper' style='font-size: 12px; mso-line-height-alt: 18px; color: #1d1d1b; line-height: 1.5; font-family: Lato, Tahoma, Verdana, Segoe, sans-serif;'>
                                                                                <p style='margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 24px;'><span style='font-size:16px;'>{{P}}</span></p>
                                                                                <p style='margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 18px;'> </p>
                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td class='column column-2 last' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 50px; padding-right: 50px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='50%'>
                                                            <table border='0' cellpadding='0' cellspacing='0' class='empty_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
                                                                <tr>
                                                                    <td style='padding-right:0px;padding-bottom:5px;padding-left:0px;padding-top:40px;'>
                                                                        <div></div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-5' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
                                <tbody>
                                    <tr>
                                        <td>
                                            <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
                                                <tbody>
                                                    <tr>
                                                        <td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 50px; padding-right: 50px; padding-top: 30px; padding-bottom: 30px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
                                                            <table border='0' cellpadding='0' cellspacing='0' class='heading_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
                                                                <tr>
                                                                    <td style='padding-bottom:15px;padding-left:30px;padding-right:30px;text-align:center;width:100%;padding-top:20px;'>
                                                                        <h2 style='margin: 0; color: #000000; direction: ltr; font-family: 'Playfair Display', Georgia, serif; font-size: 22px; font-weight: 400; letter-spacing: normal; line-height: 120%; text-align: center; margin-top: 0; margin-bottom: 0;'><span class='tinyMce-placeholder'>Poll info</span></h2>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table border='0' cellpadding='0' cellspacing='0' class='divider_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
                                                                <tr>
                                                                    <td style='padding-bottom:10px;padding-right:10px;padding-top:10px;'>
                                                                        <div align='center'>
                                                                            <table border='0' cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='15%'>
                                                                                <tr>
                                                                                    <td class='divider_inner' style='font-size: 1px; line-height: 1px; border-top: 2px solid #FFD3C5;'><span> </span></td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-6' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
                                <tbody>
                                    <tr>
                                        <td>
                                            <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
                                                <tbody>
                                                    <tr>
                                                        <td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 50px; padding-right: 50px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='50%'>
                                                            <table border='0' cellpadding='0' cellspacing='0' class='empty_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
                                                                <tr>
                                                                    <td style='padding-right:0px;padding-bottom:5px;padding-left:0px;padding-top:5px;'>
                                                                        <div></div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td class='column column-2' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 50px; padding-right: 50px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='50%'>
                                                            <table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
                                                                <tr>
                                                                    <td style='padding-top:20px;padding-bottom:20px;'>
                                                                        <div style='font-family: sans-serif'>
                                                                            <div class='txtTinyMce-wrapper' style='font-size: 12px; font-family: Lato, Tahoma, Verdana, Segoe, sans-serif; mso-line-height-alt: 21.6px; color: #1d1d1b; line-height: 1.8;'>
                                                                                <p style='margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 25.2px;'><span style='font-size:14px;'>➺ Voting ends by: 22012 -12-30<br /></span><br /><span style='font-size:14px;'>➺ Voting is protected<br /></span><br /><span style='font-size:14px;'>➺ Other</span></p>
                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-7' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
                                <tbody>
                                    <tr>
                                        <td>
                                            <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
                                                <tbody>
                                                    <tr>
                                                        <td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 50px; padding-right: 50px; padding-top: 50px; padding-bottom: 10px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
                                                            <table border='0' cellpadding='0' cellspacing='0' class='empty_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
                                                                <tr>
                                                                    <td>
                                                                        <div></div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-8' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
                                <tbody>
                                    <tr>
                                        <td>
                                            <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
                                                <tbody>
                                                    <tr>
                                                        <td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 50px; padding-right: 50px; padding-top: 15px; padding-bottom: 15px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
                                                            <div class='spacer_block' style='height:40px;line-height:40px;font-size:1px;'> </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-9' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
                                <tbody>
                                    <tr>
                                        <td>
                                            <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f6f1ed; color: #000000; width: 680px;' width='680'>
                                                <tbody>
                                                    <tr>
                                                        <td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 50px; padding-right: 50px; padding-top: 40px; padding-bottom: 10px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
                                                            <table border='0' cellpadding='0' cellspacing='0' class='heading_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
                                                                <tr>
                                                                    <td style='padding-bottom:15px;padding-left:30px;padding-right:30px;text-align:center;width:100%;'>
                                                                        <h2 style='margin: 0; color: #000000; direction: ltr; font-family: 'Playfair Display', Georgia, serif; font-size: 22px; font-weight: 400; letter-spacing: normal; line-height: 120%; text-align: center; margin-top: 0; margin-bottom: 0;'><span class='tinyMce-placeholder'>How to get it</span></h2>
        </td>
        </tr>
        </table>
        <table border='0' cellpadding='0' cellspacing='0' class='divider_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tr>
        <td style='padding-bottom:10px;padding-right:10px;padding-top:10px;'>
        <div align='center'>
        <table border='0' cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='15%'>
        <tr>
        <td class='divider_inner' style='font-size: 1px; line-height: 1px; border-top: 2px solid #FFD3C5;'><span> </span></td>
        </tr>
        </table>
        </div>
        </td>
        </tr>
        </table>
        <table border='0' cellpadding='10' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
        <tr>
        <td>
        <div style='font-family: sans-serif'>
        <div class='txtTinyMce-wrapper' style='font-size: 12px; mso-line-height-alt: 18px; color: #1d1d1b; line-height: 1.5; font-family: Lato, Tahoma, Verdana, Segoe, sans-serif;'>
        <p style='margin: 0; font-size: 14px; text-align: center; mso-line-height-alt: 24px;'><span style='font-size:16px;'>Get the poll project</span></p>
        </div>
        </div>
        </td>
        </tr>
        </table>
        </td>
        </tr>
        </tbody>
        </table>
        </td>
        </tr>
        </tbody>
        </table>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-5' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tbody>
        <tr>
        <td>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f6f1ed; color: #000000; width: 680px;' width='680'>
        <tbody>
        <tr>
        <td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 10px; padding-right: 10px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='33.333333333333336%'>
        <table border='0' cellpadding='0' cellspacing='0' class='empty_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tr>
        <td style='padding-right:0px;padding-bottom:10px;padding-left:0px;padding-top:10px;'>
        <div></div>
        </td>
        </tr>
        </table>
        </td>
        <td class='column column-2' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='33.333333333333336%'>
        <table border='0' cellpadding='0' cellspacing='0' class='image_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tr>
        <td style='padding-bottom:15px;padding-left:10px;padding-right:10px;padding-top:15px;width:100%;'>
        <div align='center' style='line-height:10px'><a href='https://github.com/miczek-r/SM_Projekt_API' style='outline:none' tabindex='-1' target='_blank'><img alt='Google Play' src='https://live.staticflickr.com/5622/22160892602_e5474a698d_w.jpg' style='display: block; height: auto; border: 0; width: 124px; max-width: 100%;' title='Google Play' width='124'/></a></div>
        </td>
        </tr>
        </table>
        </td>
        <td class='column column-3' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='33.333333333333336%'>
        <table border='0' cellpadding='0' cellspacing='0' class='empty_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tr>
        <td style='padding-right:0px;padding-bottom:5px;padding-left:0px;padding-top:5px;'>
        <div></div>
        </td>
        </tr>
        </table>
        </td>
        </tr>
        </tbody>
        </table>
        </td>
        </tr>
        </tbody>
        </table>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-6' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tbody>
        <tr>
        <td>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f6f1ed; color: #000000; width: 680px;' width='680'>
        <tbody>
        <tr>
        <td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
        <div class='spacer_block' style='height:30px;line-height:30px;font-size:1px;'> </div>
        </td>
        </tr>
        </tbody>
        </table>
        </td>
        </tr>
        </tbody>
        </table>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-7' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tbody>
        <tr>
        <td>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffd3c5; color: #000000; width: 680px;' width='680'>
        <tbody>
        <tr>
        <td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 20px; padding-bottom: 15px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
        <table border='0' cellpadding='0' cellspacing='0' class='empty_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tr>
        <td>
        <div></div>
        </td>
        </tr>
        </table>
        </td>
        </tr>
        </tbody>
        </table>
        </td>
        </tr>
        </tbody>
        </table>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-8' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tbody>
        <tr>
        <td>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #3f3f3f; color: #000000; width: 680px;' width='680'>
        <tbody>
        <tr>
        <td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
        <table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
        <tr>
        <td style='padding-bottom:30px;padding-left:30px;padding-right:30px;padding-top:15px;'>
        <div style='font-family: sans-serif'>
        <div class='txtTinyMce-wrapper' style='font-size: 12px; font-family: Lato, Tahoma, Verdana, Segoe, sans-serif; mso-line-height-alt: 18px; color: #afafaf; line-height: 1.5;'>
        <p style='margin: 0; font-size: 10px; text-align: center;'>Project is free to use and made for educational purposes.</p>
        </div>
        </div>
        </td>
        </tr>
        </table>
        </td>
        </tr>
        </tbody>
        </table>
        </td>
        </tr>
        </tbody>
        </table>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-9' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tbody>
        <tr>
        <td>
        <table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'>
        <tbody>
        <tr>
        <td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
        <table border='0' cellpadding='0' cellspacing='0' class='icons_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tr>
        <td style='vertical-align: middle; color: #9d9d9d; font-family: inherit; font-size: 15px; padding-bottom: 5px; padding-top: 5px; text-align: center;'>
        <table cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
        <tr>
        <td style='vertical-align: middle; text-align: center;'>
        <!--[if vml]><table align='left' cellpadding='0' cellspacing='0' role='presentation' style='display:inline-block;padding-left:0px;padding-right:0px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;'><![endif]-->
        <!--[if !vml]><!-->
        <table cellpadding='0' cellspacing='0' class='icons-inner' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; display: inline-block; margin-right: -4px; padding-left: 0px; padding-right: 0px;'>
        <!--<![endif]-->
        <tr>
        <td style='vertical-align: middle; text-align: center; padding-top: 5px; padding-bottom: 5px; padding-left: 5px; padding-right: 6px;'><a href='https://www.designedwithbee.com/' style='text-decoration: none;' target='_blank'><img align='center' alt='Designed with BEE' class='icon' height='32' src='https://beefree.io/wp-content/themes/bee2017/img/logo-bee.svg' style='display: block; height: auto; margin: 0 auto; border: 0;' width='34'/></a></td>
        <td style='font-family: Lato, Tahoma, Verdana, Segoe, sans-serif; font-size: 15px; color: #9d9d9d; vertical-align: middle; letter-spacing: undefined; text-align: center;'><a href='https://www.designedwithbee.com/' style='color: #9d9d9d; text-decoration: none;' target='_blank'>Designed with BEE</a></td>
        </tr>
        </table>
        </td>
        </tr>
        </table>
        </td>
        </tr>
        </table>
        </td>
        </tr>
        </tbody>
        </table>
        </td>
        </tr>
        </tbody>
        </table>
        </td>
        </tr>
        </tbody>
        </table><!-- End -->
        </body>
        </html>";
    }

}