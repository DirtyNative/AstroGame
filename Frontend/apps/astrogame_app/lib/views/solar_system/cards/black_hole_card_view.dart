import 'package:astrogame_app/models/stellar/stellar_objects/black_hole.dart';
import 'package:flutter/material.dart';

class BlackHoleCardView extends StatelessWidget {
  final BlackHole _blackHole;

  BlackHoleCardView(this._blackHole);

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 70,
      child: Row(
        children: [
          ImageIcon(
            AssetImage('assets/images/black_hole@64px.png'),
            color: Colors.white,
            size: 50,
          ),
          SizedBox(width: 16),
          Text('${_blackHole.name}'),
          SizedBox(width: 16),
          Text(_blackHole.coordinates.toString())
        ],
      ),
    );
  }
}
