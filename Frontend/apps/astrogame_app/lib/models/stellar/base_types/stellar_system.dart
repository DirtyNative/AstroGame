import 'package:astrogame_app/converters/guid_converter.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_thing.dart';

@GuidConverter()
abstract class StellarSystem extends StellarThing {}
