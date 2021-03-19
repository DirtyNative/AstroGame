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
      child: GestureDetector(
        onTap: onTap,
        child: AnimatedContainer(
          duration: Duration(milliseconds: 300),
          decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(16),
            gradient: (isSelected) ? _gradient : _transparentGradient,
          ),
          padding: EdgeInsets.all(16),
          child: Row(
            children: [
              Icon(
                icon,
                size: 24,
              ),
              SizedBox(width: 16),
              Text(
                label,
                style: Theme.of(context).textTheme.subtitle1,
              ),
            ],
          ),
        ),
      ),
    );
  }
}
