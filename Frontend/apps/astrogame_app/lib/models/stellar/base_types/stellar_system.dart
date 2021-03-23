import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_thing.dart';
import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class StellarSystem extends StellarThing {
  @JsonKey()
  List<StellarObject> centerObjects;

  @JsonKey()
  List<StellarSystem> satellites;
}
