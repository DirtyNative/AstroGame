import 'package:astrogame_app/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/coordinates.dart';
import 'package:astrogame_app/models/resources/stellar_object_resource.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:json_annotation/json_annotation.dart';

part 'black_hole.g.dart';

@GuidConverter()
@JsonSerializable()
class BlackHole extends StellarObject {
  @JsonKey()
  List<StellarObjectResource> resources;

  BlackHole();

  factory BlackHole.fromJson(Map<String, dynamic> json) =>
      _$BlackHoleFromJson(json);
  Map<String, dynamic> toJson() => _$BlackHoleToJson(this);
}
