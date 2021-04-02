import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:flutter/material.dart';

class MenuItem extends StatelessWidget {
  final bool isSelected;
  final IconData icon;
  final String label;
  final Function onTap;

  MenuItem({
    @required this.icon,
    @required this.label,
    @required this.isSelected,
    @required this.onTap,
  });

  final _gradient = LinearGradient(
      begin: Alignment.centerLeft,
      end: Alignment.centerRight,
      colors: [AstroGameColors.purple, AstroGameColors.torque]);

  final _transparentGradient =
      LinearGradient(colors: [Colors.transparent, Colors.transparent]);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.only(top: 8, bottom: 8),
      child: AnimatedContainer(
        height: 60,
        duration: Duration(milliseconds: 300),
        decoration: BoxDecoration(
          borderRadius: BorderRadius.only(
              topRight: Radius.circular(16), bottomRight: Radius.circular(16)),
          gradient: (isSelected) ? _gradient : _transparentGradient,
        ),
        child: Material(
          color: Colors.transparent,
          child: InkWell(
            hoverColor: AstroGameColors.purple[100],
            borderRadius: BorderRadius.only(
                topRight: Radius.circular(16),
                bottomRight: Radius.circular(16)),
            onTap: onTap,
            child: Padding(
              padding:
                  const EdgeInsets.only(left: 16, right: 8, top: 4, bottom: 4),
              child: Row(
                children: [
                  Icon(
                    icon,
                    size: 24,
                  ),
                  SizedBox(width: 16),
                  Text(
                    label,
                    style: Theme.of(context).textTheme.button,
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
