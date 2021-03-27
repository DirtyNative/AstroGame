import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:bitsdojo_window/bitsdojo_window.dart';
import 'package:flutter/material.dart';

class AppHeader extends StatelessWidget {
  final buttonColors = WindowButtonColors(
      iconNormal: Colors.white,
      mouseOver: AstroGameColors.purple,
      mouseDown: AstroGameColors.purple[800],
      iconMouseOver: Colors.white,
      iconMouseDown: Color(0xFFFFD500));

  final closeButtonColors = WindowButtonColors(
    mouseOver: Color(0xFFD32F2F),
    mouseDown: Color(0xFFB71C1C),
    iconNormal: Colors.white,
    iconMouseOver: Colors.white,
  );

  @override
  Widget build(BuildContext context) {
    return Container(
      color: AstroGameColors.darkGrey,
      child: WindowTitleBarBox(
        child: Row(
          children: [
            Expanded(child: MoveWindow()),
            MinimizeWindowButton(colors: buttonColors),
            MaximizeWindowButton(colors: buttonColors),
            CloseWindowButton(colors: closeButtonColors),
          ],
        ),
      ),
    );
  }
}
