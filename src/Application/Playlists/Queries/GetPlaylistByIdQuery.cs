using Application.Interfaces;
using Application.Playlists.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Playlists.Queries;

public sealed record GetPlaylistByIdQuery(int Id) : IQuery<PlaylistViewModel>;
