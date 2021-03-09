import 'package:astrogame_app/converters/guid_converter.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_thing.dart';
import 'package:flutter_guid/flutter_guid.dart';

@GuidConverter()
abstract class StellarSystem extends StellarThing {
  StellarSystem(Guid id, String name) : super(id, name);
}
